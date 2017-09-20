namespace CatLib.Ui
{
    public class MaskEventListener
    {
        public MaskEventListener()
        {
            App.Listen("mask.show", (payload) =>
            {
                if (payload == null) payload = "";
                return Mask.Instance.ShowMask(payload.ToString());
            });

            App.Listen("mask.hide", (payload) =>
            {
                var maskId = payload.ToString();
                Mask.Instance.HideMask(maskId);
                return false;
            });

        }
    }
}