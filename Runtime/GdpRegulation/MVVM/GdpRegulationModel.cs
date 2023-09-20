namespace EM.GameKit.UI
{

public sealed class GdpRegulationModel
{
	public bool IsAccepted { get; private set; }

	public void Accept()
	{
		IsAccepted = true;
	}
}

}