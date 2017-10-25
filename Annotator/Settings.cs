using System.ComponentModel;
using System.Configuration;

namespace Annotator.Properties
{
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("")]
        [Category("General")]
        [Description("Forder containing the images to annotate")]
        [DisplayName("Image Folder")]
        public string ImageFolder
        {
            get
            {
                return ((string)(this["ImageFolder"]));
            }
            set
            {
                this["ImageFolder"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("{0:F0} {1,4:F0} {2,4:F0} {3,4:F0}")]
        [Category("General")]
        [Description("Format of the rectangle line. X=0, Y=1, Width=2, Height=3")]
        [DisplayName("Rectangle line format")]
        public string RectangleLineFormat
        {
            get
            {
                return ((string)(this["RectangleLineFormat"]));
            }
            set
            {
                this["RectangleLineFormat"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Cyan")]
        [Category("General")]
        [Description("Color for the annotation rectangles.")]
        [DisplayName("Rectangle Color")]
        public global::System.Drawing.Color RectangleColor
        {
            get
            {
                return ((global::System.Drawing.Color)(this["RectangleColor"]));
            }
            set
            {
                this["RectangleColor"] = value;
            }
        }
    }
}