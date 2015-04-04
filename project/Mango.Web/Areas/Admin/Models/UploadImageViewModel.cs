using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mango.Web.Areas.Admin.Models
{
    /// <summary>
    /// View Model for modal image uploader
    /// </summary>
    public class UploadImageViewModel
    {
        public string ModalId { get; set; }
        public string OptionsVarName { get; private set; }

        public UploadImageViewModel(string modalId)
        {
            ModalId = modalId;
            OptionsVarName = string.Format("{0}Options", modalId);
        }
    }
}