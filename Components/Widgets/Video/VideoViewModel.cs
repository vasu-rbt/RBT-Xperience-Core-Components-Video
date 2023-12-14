namespace RBT.Xperience.Core.Components.VideoWidget.Components.Widgets.Video
{
    public class VideoViewModel
    {
        /// <summary>
        ///  IsVisibility Feature to Editor
        /// </summary>
        public bool? IsVisible { get; set; }

        /// <summary>
        /// Declairing to add the title
        /// </summary>
        public bool? AddTitle { get; set; }

        /// <summary>
        /// Declaring Video Title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Declaring the Video Type
        /// </summary>
        public string? VideoType { get; set; }

        /// <summary>
        /// Declaring Video Source
        /// </summary>
        public string? VideoSource { get; set; }

        /// <summary>
        /// Declaring Video Source for Media Library
        /// </summary>
        public string? VideoSourceML { get; set; }

        /// <summary>
        /// Declaring CoverImage field for Video
        /// </summary>
        public string? CoverImage { get; set; }

        /// <summary>
        /// Declaring CoverImage field for Video
        /// </summary>
        public string? AltText { get; set; }

        /// <summary>
        /// Declaring ThumbnailImage for give a play icon on the video
        /// </summary>
        public string? ThumbnailImage { get; set; }

        /// <summary>
        ///  IsAutoplay will allow user to make the video auto play
        /// </summary>
        public bool? IsAutoPlay { get; set; }
        /// <summary>
        /// ExtractedURL will be extract some part of embedded URL to add auto play
        /// </summary>
        public string? ExtractedURL { get; set; }
        /// <summary>
        /// View
        /// </summary>
        public string? ViewName { get; set; }
    }
}
