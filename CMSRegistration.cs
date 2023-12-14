using CMS;
using Kentico.PageBuilder.Web.Mvc;
using RBT.Xperience.Core.Components.VideoWidget.Components.Widgets.Video;

[assembly: AssemblyDiscoverable]
[assembly: RegisterWidget(VideoViewComponent.IDENTIFIER, typeof(VideoViewComponent), "Video Widget", typeof(VideoProperties), Description = "A video widget allows playing short looping videos with or without audio. When set to autoplay, there's no visible play/pause button, but controls appear if autoplay is disabled. Optional title can be added", IconClass = "icon-clapperboard")]