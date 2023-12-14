using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RBT.Xperience.Core.Components.VideoWidget.Components.Widgets.Video
{
    public class VideoProperties : IWidgetProperties
    {

        /// <summary>
        /// Declaring the widget will visible or not
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 0, Label = "Visible", Tooltip = "Set the visibility for widget to render")]
        public bool? IsVisible { get; set; } = true;

        /// <summary>
        /// Declaring the Title will visible or not
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 1, Label = "Add Title", Tooltip = "Enable to add the Title")]
        public bool? AddTitle { get; set; } = false;

        /// <summary>
        /// Declaring to enter the video Title
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Title", Tooltip = "Enter the Title.")]
        [VisibilityCondition(nameof(AddTitle), ComparisonTypeEnum.IsTrue)]
        [EditingComponentProperty("Size", 200)]
        public string? Title { get; set; }

        /// <summary>
        /// Declaring to select the video type
        /// You can bring the drop down value from resource string or custom table as well
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Order = 3, Label = "Video Type", Tooltip = "Select the type of source.")]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "_external_Source;External Source\r\n_media_Library;Media Library")]
        [Required(ErrorMessage = "Please select value")]
        public string? VideoType { get; set; }

        /// <summary>
        /// Declaring to select the video source
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Video Source", Tooltip = "Enter the video URL.")]
        [VisibilityCondition(nameof(VideoType), ComparisonTypeEnum.IsEqualTo, "_external_Source", StringComparison = StringComparison.OrdinalIgnoreCase)]
        [EditingComponentProperty("Size", 200)]
        public string? VideoSource { get; set; }

        /// <summary>
        /// Declaring to select video from media library
        /// </summary>
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Video Source", Order = 5, Tooltip = "Select the video URL.")]
        [VisibilityCondition(nameof(VideoType), ComparisonTypeEnum.IsEqualTo, "_media_Library", StringComparison = StringComparison.OrdinalIgnoreCase)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        public IEnumerable<MediaFilesSelectorItem>? VideoSourceML { get; set; }

        /// <summary>
        /// Declaring to select Cover Image
        /// </summary>
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Cover Image", Order = 6, Tooltip = "Select the Cover Image.", ExplanationText = "Please select Only JPG or PNG files. Please upload the image of size not more than 100kb.")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg;.svg;.webp")]
        [VisibilityCondition(nameof(VideoType), ComparisonTypeEnum.IsEqualTo, "_media_Library", StringComparison = StringComparison.OrdinalIgnoreCase)]
        public IEnumerable<MediaFilesSelectorItem>? CoverImage { get; set; }

        //[EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 3, Label = "Hero Image - Small*")]
        //[EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        //[EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg;.svg;.webp")]
        //public IEnumerable<MediaFilesSelectorItem>? ImageSmall { get; set; }

        /// <summary>
        /// Declaring to enter the Alt text for image
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 7, Label = "Alt Text", Tooltip = "Enter the Title.")]
        [EditingComponentProperty("Size", 200)]
        [VisibilityCondition(nameof(VideoType), ComparisonTypeEnum.IsEqualTo, "_media_Library", StringComparison = StringComparison.OrdinalIgnoreCase)]
        public string? AltText { get; set; }

        /// <summary>
        /// Declaring to select Thumbnail Image for Video
        /// </summary>
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Play Icon Image", Order = 8, Tooltip = "Select the Play Icon Image.", ExplanationText = "Please select Only JPG or PNG files. Please upload the image of size not more than 100kb.")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg;.svg;.webp")]
        [VisibilityCondition(nameof(VideoType), ComparisonTypeEnum.IsEqualTo, "_media_Library", StringComparison = StringComparison.OrdinalIgnoreCase)]
        public IEnumerable<MediaFilesSelectorItem>? ThumbnailImage { get; set; }

        /// <summary>
        /// Declaring the video will auto play or not
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 9, Label = "IsAutoplay", Tooltip = "Set the video will autoplay or not")]
        public bool? IsAutoplay { get; set; } = false;
        /// <summary>
        /// View
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Transformation", Order = 10)]
        public string? ViewName { get; set; }

    }
}
