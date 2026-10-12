namespace ServiceLib.Tests.Manager;

public class CoreInfoManagerTests
{
    [Test]
    public async Task AppUpdates_AreDisabledForTheCustomizedClient()
    {
        var manager = CoreInfoManager.Instance;

        await manager.IsCheckUpdateSupported(ECoreType.v2rayN).Should().BeFalse();
        await manager.GetCheckUpdateCoreTypes().Contains(ECoreType.v2rayN).Should().BeFalse();
    }

    [Test]
    [Arguments(ECoreType.Xray)]
    [Arguments(ECoreType.mihomo)]
    [Arguments(ECoreType.sing_box)]
    public async Task CoreUpdates_RemainSupported(ECoreType coreType)
    {
        await CoreInfoManager.Instance.IsCheckUpdateSupported(coreType).Should().BeTrue();
    }
}
