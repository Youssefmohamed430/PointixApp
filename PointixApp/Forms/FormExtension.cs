using FontAwesome.Sharp;
using PointixApp.DataLayer;
using PointixApp.Managers;
using PointixApp.Patterns;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace PointixApp.Forms
{
    public static class FormExtension
    {
        private static Mediator mediator { get; set; }
        public static void LoadNotifications(this Form form, Mediator _mediator, Panel NotificationPanel, int id, INotificationService notificationService)
        {
            NotificationPanel.Controls.Clear();
            NotificationPanel.AutoScroll = true;
            var notifications = notificationService.SendNotifications(id);

            if (notifications.Count() == 0)
            {
                Label noNotificationsLabel = new Label();
                noNotificationsLabel.Text = ManageLanguages.Language == "en" ? "No new notifications" : "لا توجد اشعارات جديدة";
                noNotificationsLabel.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                noNotificationsLabel.ForeColor = Color.Gray;
                noNotificationsLabel.Dock = DockStyle.Fill;
                noNotificationsLabel.TextAlign = ContentAlignment.MiddleCenter;
                NotificationPanel.Controls.Add(noNotificationsLabel);
                return;
            }

            int yOffset = 0;

            foreach (var notif in notifications)
            {
                Panel notifCard = new Panel();
                notifCard.Width = NotificationPanel.Width - 5;
                notifCard.Height = 60; 
                notifCard.Location = new Point(0, yOffset); 
                notifCard.BorderStyle = BorderStyle.None;

                var icon = new PictureBox
                {
                    Size = new Size(15, 15),
                    Location = new Point(15, 22),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent
                };

                Label message = new Label();
                message.Text = notif.notification.Message;
                message.Location = new Point(45, 8);
                message.Size = new Size(notifCard.Width - 150, 30);
                message.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                message.BackColor = Color.Transparent;
                message.AutoEllipsis = true;
                message.Height = message.PreferredHeight;

                // تاريخ الإشعار
                Label dateLabel = new Label();
                dateLabel.Text = notif.notification.NotifDate.ToString("dd MMM yyyy - hh:mm tt");
                dateLabel.Font = new Font("Segoe UI", 8f, FontStyle.Italic);
                dateLabel.Location = new Point(65, 38);
                dateLabel.Size = new Size(150, 20);
                dateLabel.ForeColor = Color.Gray;
                dateLabel.BackColor = Color.Transparent;

                // زر التأكيد 
                IconButton ConfirmButton = new IconButton();
                ConfirmButton.IconChar = IconChar.CheckCircle;
                ConfirmButton.IconColor = Color.FromArgb(40, 167, 69); 
                ConfirmButton.IconSize = 24;
                ConfirmButton.Size = new Size(30, 30);
                ConfirmButton.Location = new Point(notifCard.Width - 30, 17);
                ConfirmButton.BackColor = Color.Transparent;
                ConfirmButton.FlatStyle = FlatStyle.Flat;
                ConfirmButton.FlatAppearance.BorderSize = 0;
                ConfirmButton.Cursor = Cursors.Hand;

                ConfirmButton.Click += (sender, e) =>
                {
                    mediator = _mediator;
                    mediator.NotificationService.MarkAsRead(notif.notification.NotifId, id);
                    form.LoadNotifications(_mediator, NotificationPanel, id, notificationService);
                };

                notifCard.Controls.Add(icon);
                notifCard.Controls.Add(message);
                notifCard.Controls.Add(dateLabel);
                notifCard.Controls.Add(ConfirmButton);

                if (notif.notification.Type == "Warning")
                {
                    notifCard.BackColor = Color.FromArgb(252, 248, 227);
                    message.ForeColor = Color.FromArgb(138, 109, 59);
                    icon.Image = SystemIcons.Warning.ToBitmap();

                    Panel colorStrip = new Panel();
                    colorStrip.BackColor = Color.FromArgb(255, 193, 7);
                    colorStrip.Size = new Size(4, notifCard.Height);
                    colorStrip.Location = new Point(0, 0);
                    notifCard.Controls.Add(colorStrip);
                }
                else if (notif.notification.Type == "Problem")
                {
                    notifCard.BackColor = Color.FromArgb(248, 215, 218); 
                    message.ForeColor = Color.FromArgb(169, 68, 66);
                    icon.Image = SystemIcons.Error.ToBitmap();

                    Panel colorStrip = new Panel();
                    colorStrip.BackColor = Color.FromArgb(220, 53, 69);
                    colorStrip.Size = new Size(4, notifCard.Height);
                    colorStrip.Location = new Point(0, 0);
                    notifCard.Controls.Add(colorStrip);
                }
                else
                {
                    notifCard.BackColor = Color.FromArgb(217, 237, 247);
                    message.ForeColor = Color.FromArgb(49, 112, 143);
                    icon.Image = SystemIcons.Information.ToBitmap();

                    Panel colorStrip = new Panel();
                    colorStrip.BackColor = Color.FromArgb(23, 162, 184);
                    colorStrip.Size = new Size(4, notifCard.Height);
                    colorStrip.Location = new Point(0, 0);
                    notifCard.Controls.Add(colorStrip);
                }

                NotificationPanel.Controls.Add(notifCard);
                yOffset += notifCard.Height + 1;
            }
        }
        public static void TextBoxClick(this Form form, TextBox textBox, string text)
        {
            if (textBox.Text == text)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }
        public static void TextBoxLeave(this Form form,TextBox textBox, string text)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
                textBox.ForeColor = SystemColors.ScrollBar;
            }

        }
        
        public static void DrawPointixLogo(this Form form,Graphics g, int x, int y)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Use provided coordinates as center
            int centerX = x;
            int centerY = y;

            DrawCubeIcon(g, centerX + 35, centerY + 30);
        }
        private static void DrawCubeIcon(Graphics g, int centerX, int centerY)
        {
            // Define cube colors
            Color cubeBlue = Color.FromArgb(70, 130, 180);
            Color cubeLight = Color.FromArgb(100, 160, 210);
            Color cubeDark = Color.FromArgb(50, 100, 150);

            // Cube dimensions
            int size = 20;
            int depth = 10;

            // Define cube points
            Point[] frontFace = {
            new Point(centerX - size/2, centerY - size/2),
            new Point(centerX + size/2, centerY - size/2),
            new Point(centerX + size/2, centerY + size/2),
            new Point(centerX - size/2, centerY + size/2)
        };

            Point[] topFace = {
            new Point(centerX - size/2, centerY - size/2),
            new Point(centerX + size/2, centerY - size/2),
            new Point(centerX + size/2 + depth, centerY - size/2 - depth),
            new Point(centerX - size/2 + depth, centerY - size/2 - depth)
        };

            Point[] rightFace = {
            new Point(centerX + size/2, centerY - size/2),
            new Point(centerX + size/2 + depth, centerY - size/2 - depth),
            new Point(centerX + size/2 + depth, centerY + size/2 - depth),
            new Point(centerX + size/2, centerY + size/2)
        };

            // Draw cube faces
            using (Brush frontBrush = new SolidBrush(cubeBlue))
            using (Brush topBrush = new SolidBrush(cubeLight))
            using (Brush rightBrush = new SolidBrush(cubeDark))
            using (Pen cubePen = new Pen(Color.White, 2))
            {
                // Fill faces
                g.FillPolygon(frontBrush, frontFace);
                g.FillPolygon(topBrush, topFace);
                g.FillPolygon(rightBrush, rightFace);

                // Draw edges
                g.DrawPolygon(cubePen, frontFace);
                g.DrawPolygon(cubePen, topFace);
                g.DrawPolygon(cubePen, rightFace);
            }
        }
    }
}
