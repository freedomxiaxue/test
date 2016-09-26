using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcpjw3.oa.ViewModels
{
    public class HtmlEditorFeaturesDemosHelper
    {
        public const string ImagesDirectory = "~/Content/HtmlEditor/Images/";
        public const string ThumbnailsDirectory = "~/Content/HtmlEditor/Thumbnails/";
        public const string UploadDirectory = "~/Content/HtmlEditor/UploadFiles/";
        public const string HtmlLocation = "~/Content/HtmlEditor/DemoHtml/";

        public static readonly UploadControlValidationSettings ImageUploadValidationSettings = new UploadControlValidationSettings
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" },
            MaxFileSize = 4000000
        };

        static HtmlEditorValidationSettings validationSettings;
        public static HtmlEditorValidationSettings ValidationSettings
        {
            get
            {
                if (validationSettings == null)
                {
                    validationSettings = new HtmlEditorValidationSettings();
                    validationSettings.RequiredField.IsRequired = true;
                }
                return validationSettings;
            }
        }

        static MVCxHtmlEditorImageSelectorSettings imageSelectorSettings;
        public static HtmlEditorImageSelectorSettings ImageSelectorSettings
        {
            get
            {
                if (imageSelectorSettings == null)
                {
                    imageSelectorSettings = new MVCxHtmlEditorImageSelectorSettings();
                    SetHtmlEditorImageSelectorSettings(imageSelectorSettings);
                }
                return imageSelectorSettings;
            }
        }
        public static MVCxHtmlEditorImageSelectorSettings SetHtmlEditorImageSelectorSettings(MVCxHtmlEditorImageSelectorSettings settingsImageSelector)
        {
            settingsImageSelector.UploadCallbackRouteValues = new { Controller = "Features", Action = "FeaturesImageSelectorUpload" };

            settingsImageSelector.Enabled = true;
            settingsImageSelector.CommonSettings.RootFolder = ImagesDirectory;
            settingsImageSelector.CommonSettings.ThumbnailFolder = ThumbnailsDirectory;
            settingsImageSelector.CommonSettings.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" };
            settingsImageSelector.EditingSettings.AllowCreate = true;
            settingsImageSelector.EditingSettings.AllowDelete = true;
            settingsImageSelector.EditingSettings.AllowMove = true;
            settingsImageSelector.EditingSettings.AllowRename = true;
            settingsImageSelector.UploadSettings.Enabled = true;
            settingsImageSelector.FoldersSettings.ShowLockedFolderIcons = true;

            settingsImageSelector.PermissionSettings.AccessRules.Add(
                new FileManagerFolderAccessRule
                {
                    Path = "",
                    Upload = Rights.Deny
                });
            return settingsImageSelector;
        }

        public static string GeHtmlContentByFileName(string fileName)
        {
            return System.IO.File.ReadAllText(System.Web.HttpContext.Current.Request.MapPath(string.Format("{0}{1}", HtmlLocation, fileName)));
        }
        public static string GeHtmlContentByFileName(string fileName, bool demoPageIsInRoot)
        {
            string result = GeHtmlContentByFileName(fileName);
            return demoPageIsInRoot ? result : result.Replace("Content/", "../Content/");
        }
    }
}