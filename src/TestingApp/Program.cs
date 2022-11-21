/*
using PlexShareScreenshare.Client;

ScreenCapturer screenCapturer = new ScreenCapturer();
ScreenProcessor screenProcessor = new(screenCapturer);

screenCapturer.StartCapture();
Thread.Sleep(100);
screenCapturer.StopCapture();
int v1 = screenCapturer.GetCapturedFrameLength();

screenProcessor.StartProcessing();
Thread.Sleep(500);
screenProcessor.StopProcessing();
int v2 = screenProcessor.GetProcessedFrameLength();
*/
Console.WriteLine("Hello world");
//Assert.Equal(v1, v2);