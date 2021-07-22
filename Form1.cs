using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Total_Commander
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lv_adauga_coloane(ListView lv)
        {
            lv.Columns.Add("Name", (int)(lv.Width * 0.5));
            lv.Columns.Add("Ext", (int)(lv.Width * 0.1));
            lv.Columns.Add("Size", (int)(lv.Width * 0.2));
            lv.Columns.Add("Date", (int)(lv.Width * 0.2));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Aflarea dimensiunilor ecranului pentru a putea baza elementele din form pe procentaje din dimensiuni

            int latimeEcran = Screen.PrimaryScreen.Bounds.Width;
            int inaltimeEcran = Screen.PrimaryScreen.Bounds.Height;

            Width = (int)(latimeEcran * 0.75);
            Height = (int)(inaltimeEcran * 0.75);

            Location = new Point((int)(latimeEcran * 0.125), (int)(inaltimeEcran * 0.125));


            // Locatia si Dimensiunile primului listview si combobox-ului cu partitiile disponibile si textbox-ul path-ului

            lv_locatie_1.Width = Width / 2 - 2;
            lv_locatie_1.Height = (int)(Height * 0.9);
            lv_locatie_1.Location = new Point(2, (int)(Height * 0.1));

            cb_partitie_1.Location = new Point(2, (int)(Height * 0.047));
            tb_path_1.Location = new Point(2, (int)(Height * 0.075));

            //Locatia si Dimensiunile la al doilea listview si combobox cu partitiile si textbox-ul path-ul

            lv_locatie_2.Width = Width / 2 - 2;
            lv_locatie_2.Height = (int)(Height * 0.9);
            lv_locatie_2.Location = new Point(Width / 2 + 2, (int)(Height * 0.1));

            cb_partitie_2.Location = new Point(Width / 2 + 2, (int)(Height * 0.047));
            tb_path_2.Location = new Point(Width / 2 + 2, (int)(Height * 0.075));

            // Adaugarea numelor partitiilor in combobox-urile de selectare a partitiilor disponibile

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                cb_partitie_1.Items.Add(d.Name);
                cb_partitie_2.Items.Add(d.Name);
            }

            cb_partitie_1.SelectedIndex = 0;
            cb_partitie_2.SelectedIndex = 1;

            lv_locatie_1.View = View.Details;
            lv_locatie_2.View = View.Details;

            lv_adauga_coloane(lv_locatie_1);
            lv_adauga_coloane(lv_locatie_2);


        }


        private void cb_partitions_1_SelectedIndexChanged(object sender, EventArgs e)
        {

            tb_path_1.Text = cb_partitie_1.Text;

        }

        private void cb_partitie_2_SelectedIndexChanged(object sender, EventArgs e)
        {

            tb_path_2.Text = cb_partitie_2.Text;

        }

        private void tb_path_1_TextChanged(object sender, EventArgs e)
        {

            // Stergem toate itemele din listview atunci cand selectam sa vedem o alta partitie

            lv_locatie_1.Items.Clear();


            // Adaugam imaginea pentru foldere si pentru itemul de mers inapoi cu un folder

            var imageList = new ImageList();

            imageList.Images.Add("folderImage", Image.FromFile("folderIcon.ico"));
            imageList.Images.Add("gobackfolderImage", Image.FromFile("gobackfolderIcon.png"));

            ListViewItem item_for_image;

            if (Directory.GetParent(tb_path_1.Text) != null)
            {
                var itemul_mers_inapoi = new ListViewItem(new[] { "[...]", "<DIR>", "", "" });
                item_for_image = lv_locatie_1.Items.Add(itemul_mers_inapoi);
                item_for_image.ImageIndex = imageList.Images.IndexOfKey("gobackfolderImage");
            }

            imageList.ColorDepth = ColorDepth.Depth32Bit;
            lv_locatie_1.SmallImageList = imageList;


            // Obtinem o lista cu toate folderele si o lista cu toate fisierele

            string[] toateFolderele = Directory.GetDirectories(tb_path_1.Text);
            string[] toateFisierele = Directory.GetFiles(tb_path_1.Text, "", SearchOption.TopDirectoryOnly);


            // Iteram prin toate folderele

            foreach (var folder in toateFolderele)
            {
                FileInfo info = new FileInfo(folder);

                var item = new ListViewItem(new[] { info.Name, "", "<DIR>", info.LastWriteTime.ToString() });

                item_for_image = lv_locatie_1.Items.Add(item);

                // Setam imaginea itemului bazat pe index (am folosit index si nu cheia direct deoarece era o problema de renderare la start-ul
                // programului la care nu am gasit fix

                item_for_image.ImageIndex = imageList.Images.IndexOfKey("folderImage");
            }

            // Iteram prin toate fisierele

            foreach (var fisier in toateFisierele)
            {
                FileInfo info = new FileInfo(fisier);

                // Daca icoana nu exista deja in lista noastra de imagini, o adaugam

                if (imageList.Images.ContainsKey(info.Extension + "Image") == false)
                    imageList.Images.Add(info.Extension + "Image", Icon.ExtractAssociatedIcon(info.FullName));

                var item = new ListViewItem(new[] { info.Name, info.Extension, info.Length.ToString(), info.LastWriteTime.ToString() });

                item_for_image = lv_locatie_1.Items.Add(item);
                item_for_image.ImageIndex = imageList.Images.IndexOfKey(info.Extension + "Image");
            }

        }

        // Functia asta este copiata de la textbox-ul pentru prima locatie tb_path_1 (cea din partea stanga a window-ului)
        private void tb_path_2_TextChanged(object sender, EventArgs e)
        {

            

            lv_locatie_2.Items.Clear();

            var imageList = new ImageList();

            imageList.Images.Add("folderImage", Image.FromFile("folderIcon.ico"));
            imageList.Images.Add("gobackfolderImage", Image.FromFile("gobackfolderIcon.png"));

            ListViewItem item_for_image;

            if (Directory.GetParent(tb_path_2.Text) != null)
            {
                var itemul_mers_inapoi = new ListViewItem(new[] { "[...]", "<DIR>", "", "" });
                item_for_image = lv_locatie_2.Items.Add(itemul_mers_inapoi);
                item_for_image.ImageIndex = imageList.Images.IndexOfKey("gobackfolderImage");
            }

            imageList.ColorDepth = ColorDepth.Depth32Bit;
            lv_locatie_2.SmallImageList = imageList;


            string[] toateFolderele = Directory.GetDirectories(tb_path_2.Text);
            string[] toateFisierele = Directory.GetFiles(tb_path_2.Text, "", SearchOption.TopDirectoryOnly);


            foreach (var folder in toateFolderele)
            {
                FileInfo info = new FileInfo(folder);

                var item = new ListViewItem(new[] { info.Name, "", "<DIR>", info.LastWriteTime.ToString() });

                item_for_image = lv_locatie_2.Items.Add(item);

                item_for_image.ImageIndex = imageList.Images.IndexOfKey("folderImage");
            }


            foreach (var fisier in toateFisierele)
            {
                FileInfo info = new FileInfo(fisier);

                if (imageList.Images.ContainsKey(info.Extension + "Image") == false)
                    imageList.Images.Add(info.Extension + "Image", Icon.ExtractAssociatedIcon(info.FullName));

                var item = new ListViewItem(new[] { info.Name, info.Extension, info.Length.ToString(), info.LastWriteTime.ToString() });

                item_for_image = lv_locatie_2.Items.Add(item);
                item_for_image.ImageIndex = imageList.Images.IndexOfKey(info.Extension + "Image");
            }

        }

        private void lv_locatie_1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Verificam daca este selectat doar un item
            if (lv_locatie_1.SelectedItems.Count == 1)
                // Daca are imaginea de folder sau cea pentru item-ul de redirectionare la folder-ul parinte => este un folder si trebuie intrat in el
                if (lv_locatie_1.SelectedItems[0].ImageIndex == 0 || lv_locatie_1.SelectedItems[0].ImageIndex == 1)
                {
                    if (lv_locatie_1.Items.IndexOf(lv_locatie_1.SelectedItems[0]) != 0)
                        tb_path_1.Text = tb_path_1.Text + lv_locatie_1.SelectedItems[0].Text + "/";
                    else
                    {
                        if (Directory.GetParent(tb_path_1.Text.Substring(0, tb_path_1.Text.Length - 2)).FullName != cb_partitie_1.Text)
                            tb_path_1.Text = Directory.GetParent(tb_path_1.Text.Substring(0, tb_path_1.Text.Length - 2)).FullName + "/";
                        else
                            tb_path_1.Text = cb_partitie_1.Text;
                    }
                }
                // Daca nu are imaginea de folder sau cea pentru item-ul de redirectionare la folder-ul parinte => este un fisier si trebuie sa fie deschis
                else
                {
                    var p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo(tb_path_1.Text + lv_locatie_1.SelectedItems[0].Text)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
        }

        private void lv_locatie_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (lv_locatie_2.SelectedItems.Count == 1)
                if (lv_locatie_2.SelectedItems[0].ImageIndex == 0 || lv_locatie_2.SelectedItems[0].ImageIndex == 1)
                {
                    if (lv_locatie_2.Items.IndexOf(lv_locatie_2.SelectedItems[0]) != 0)
                        tb_path_2.Text = tb_path_2.Text + lv_locatie_2.SelectedItems[0].Text + "/";
                    else
                    {
                        if (Directory.GetParent(tb_path_2.Text.Substring(0, tb_path_2.Text.Length - 2)).FullName != cb_partitie_2.Text)
                            tb_path_2.Text = Directory.GetParent(tb_path_2.Text.Substring(0, tb_path_2.Text.Length - 2)).FullName + "/";
                        else
                            tb_path_2.Text = cb_partitie_2.Text;
                    }
                }
                else
                {
                    var p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo(tb_path_2.Text + lv_locatie_2.SelectedItems[0].Text)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
        }
    }
}
