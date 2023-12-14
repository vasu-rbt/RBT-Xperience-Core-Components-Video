using CMS.Core;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using RBT.Xperience.Core.Components.VideoWidget.Components.Widgets.Video;

[assembly: RegisterWidget(VideoViewComponent.IDENTIFIER, typeof(VideoViewComponent), "Video Widget", typeof(VideoProperties), Description = "A video widget allows playing short looping videos with or without audio. When set to autoplay, there's no visible play/pause button, but controls appear if autoplay is disabled. Optional title can be added", IconClass = "icon-clapperboard")]
namespace RBT.Xperience.Core.Components.VideoWidget.Components.Widgets.Video
{
    public class VideoViewComponent: ViewComponent
    {
        public const string IDENTIFIER = "RBT.Core.Component.Video";
        private readonly IEventLogService _eventLogService;

        public VideoViewComponent(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
        }

        public async Task<IViewComponentResult> InvokeAsync(VideoProperties properties, CancellationToken? cancellationToken = null)
        {
            try
            {
                string coverimageURL = string.Empty;
                string thumbnailimageURL=string.Empty;
                string videosourceMLURL=string.Empty;
                if (properties != null)
                {
                    if (properties.CoverImage != null)
                    {

                        var coverimageguid = properties?.CoverImage?.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                        if (coverimageguid != null)
                        {
                            var imagelargeInfo = MediaFileInfoProvider.GetMediaFileInfo(coverimageguid, SiteContext.CurrentSiteName);
                            if (imagelargeInfo != null)
                            {
                                coverimageURL = MediaFileURLProvider.GetMediaFileUrl(imagelargeInfo.FileGUID, imagelargeInfo.FileName) ?? string.Empty;
                            }
                        }
                    }


                    if (properties.ThumbnailImage != null)
                    {

                        var thumbnailimageguid = properties?.ThumbnailImage?.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                        if (thumbnailimageguid != null)
                        {
                            var imagelargeInfo = MediaFileInfoProvider.GetMediaFileInfo(thumbnailimageguid, SiteContext.CurrentSiteName);
                            if (imagelargeInfo != null)
                            {
                                thumbnailimageURL = MediaFileURLProvider.GetMediaFileUrl(imagelargeInfo.FileGUID, imagelargeInfo.FileName) ?? string.Empty;
                            }
                        }
                    }


                    if (properties.VideoSourceML != null)
                    {

                        var videosourcemMLguid = properties?.VideoSourceML?.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                        if (videosourcemMLguid != null)
                        {
                            var videosourceMLInfo = MediaFileInfoProvider.GetMediaFileInfo(videosourcemMLguid, SiteContext.CurrentSiteName);
                            if (videosourceMLInfo != null)
                            {
                                videosourceMLURL = MediaFileURLProvider.GetMediaFileUrl(videosourceMLInfo.FileGUID, videosourceMLInfo.FileName) ?? string.Empty;
                            }
                        }
                    }

                    VideoViewModel VideoModel = new();
                    VideoModel.IsVisible = properties.IsVisible;
                    VideoModel.AddTitle = properties.AddTitle;
                    VideoModel.CoverImage = coverimageURL;
                    VideoModel.VideoSourceML = videosourceMLURL;
                    VideoModel.ThumbnailImage= thumbnailimageURL;
                    VideoModel.Title = properties.Title;
                    VideoModel.VideoType = properties.VideoType;
                    VideoModel.VideoSource = properties.VideoSource;
                    VideoModel.AltText = properties.AltText;
                    VideoModel.IsAutoPlay = properties.IsAutoplay;
                    if (VideoModel.VideoSource != null)
                    {
                        string searchString = "embed/";
                        int index = (VideoModel.VideoSource).IndexOf(searchString);
                        if (index != -1)
                        {
                            VideoModel.ExtractedURL = (VideoModel.VideoSource).Substring(index + searchString.Length);
                        }
                    }

                    return View("~/Components/Widgets/Video/"+properties.ViewName
                        +".cshtml", VideoModel);
                }
                else { return await Task.FromResult<IViewComponentResult>(Content(string.Empty)); }
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(VideoViewComponent), nameof(InvokeAsync), ex);
                return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
            }
        }
    }
}
