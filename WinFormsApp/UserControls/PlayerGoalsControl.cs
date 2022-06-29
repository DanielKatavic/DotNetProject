using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.Models;

namespace WinFormsApp.UserControls
{
    public partial class PlayerGoalsControl : UserControl, IComparable<PlayerGoalsControl>
    {
        private readonly StartingEleven? player;

        public PlayerGoalsControl(StartingEleven player)
        {
            InitializeComponent();
            this.player = player;
            DoubleBuffered = true;
            CheckIfImageExists();
            FillForm();
        }

        public int CompareTo(PlayerGoalsControl? other) 
            => player.NumberOfGoals.CompareTo(other?.player?.NumberOfGoals);

        private void FillForm()
        {
            lblName.Text = player?.Name?.ToUpper();
            lblNumberOfGoals.Text = player?.NumberOfGoals.ToString();
        }

        private void CheckIfImageExists()
        {
            if (player?.PicturePath is not null)
            {
                SetImageToPlayer(player.PicturePath);
            }
        }

        private void SetImageToPlayer(string path)
        {
            BackgroundImage = Image.FromFile(path);
        }
    }
}