namespace Skillup.XMLReadSearch.Utility
{
    /// <summary>
    /// Enum for Device Type.
    /// </summary>
    public enum DeviceType
    {
        A3,
        A4,
    }

    /// <summary>
    /// Enum for User Options.
    /// </summary>
    public enum UserOptions
    {
        ShowDevice = 1,
        SearchDevice = 2,
        Exit = 3,
    }

    /// <summary>
    /// Enum for All nodes which is present in Xml File.
    /// </summary>
    public enum XMLNodes
    {
        SrNo,
        Address,
        DevName,
        ModelName,
        Type,
        PortNo,
        UseSSL,
        Password
    }
}