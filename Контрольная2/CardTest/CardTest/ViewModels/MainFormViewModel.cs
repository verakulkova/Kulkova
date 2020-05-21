using CardTest.Misc;
using CardTest.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CardTest.ViewModels
{
    public class MainFormViewModel : BindableBase
    {
        private string name;
        private string email;
        private string nameSender;
        private string emailSender;
        private int checkedImage = 1;
        private string richText;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

       
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string NameSender
        {
            get
            {
                return nameSender;
            }
            set
            {
                nameSender = value;
                OnPropertyChanged(nameof(NameSender));
            }
        }


        public string EmailSender
        {
            get
            {
                return emailSender;
            }
            set
            {
                emailSender = value;
                OnPropertyChanged(nameof(EmailSender));
            }
        }

        public string RichText
        {
            get
            {
                return richText;
            }
            set
            {
                richText = value;
                //OnPropertyChanged(nameof(RichText));
            }
        }

        private Image selectedImage;
        public Image SelectedImage
        {
            get
            {
                return selectedImage;
            }
            set
            {
                selectedImage = value;
                OnPropertyChanged(nameof(SelectedImage));
            }
        }
    }
}
