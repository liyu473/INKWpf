using CommunityToolkit.Mvvm.ComponentModel;

namespace InkoreWpf.Model;

internal partial class LaserPara:ObservableObject
{
    /// <summary>
    /// 激光功率
    /// </summary>
    [ObservableProperty]
    public partial float Power { get; set; }

    /// <summary>
    /// 缓升时间
    /// </summary>
    [ObservableProperty]
    public partial int RiseTime { get; set; }

    /// <summary>
    /// 缓降时间
    /// </summary>
    [ObservableProperty]
    public partial int FallTime { get; set; }

    /// <summary>
    /// 送丝速度
    /// </summary>
    [ObservableProperty]
    public partial float FeedSpeed { get; set; }

    /// <summary>
    /// 回丝速度
    /// </summary>
    [ObservableProperty]
    public partial float RetractSpeed { get; set; }

    /// <summary>
    /// 补丝速度
    /// </summary>
    [ObservableProperty]
    public partial float RefeedSpeed { get; set; }

    /// <summary>
    /// 回丝长度
    /// </summary>
    [ObservableProperty]
    public partial float RetractLength { get; set; }

    /// <summary>
    /// 补丝长度
    /// </summary>
    [ObservableProperty]
    public partial float RefeedLength { get; set; }

    /// <summary>
    /// 延时补丝时间
    /// </summary>
    [ObservableProperty]
    public partial int DelayReFeedTime { get; set; }
}
