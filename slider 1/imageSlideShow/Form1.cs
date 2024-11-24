using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace imageSlideShow
{
    public partial class Form1 : Form
    {
        List<string> imagePaths = new List<string>
        {
           "D:\\front end\\artgallery\\src\\images\\1.jpg",
            "D:\\front end\\artgallery\\src\\images\\2.jpg",
          "D:\\front end\\artgallery\\src\\images\\3.jpg",
        };

        int currentImageIndex = 0;

        public Form1()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            if (imagePaths.Count > 0 && currentImageIndex >= 0 && currentImageIndex < imagePaths.Count)
            {
                try
                {
                    // Dispose the previous image to free memory
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }

                    // Load the new image
                    pictureBox1.Image = Image.FromFile(imagePaths[currentImageIndex]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
            }
            else
            {
                currentImageIndex = imagePaths.Count - 1; // Loop to the last image
            }
            LoadImage();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
            }
            else
            {
                currentImageIndex = 0; // Loop back to the first image
            }
            LoadImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}
    