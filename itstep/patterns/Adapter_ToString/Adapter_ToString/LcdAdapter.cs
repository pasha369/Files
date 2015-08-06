namespace Adapter_ToString
{
    /// <summary>
    /// Adapter
    /// </summary>
    class LcdAdapter : LCD.LcdDisplay, IStringAdapter
    {
        public void GetData(string input)
        {
            byte[] bytes = new byte[input.Length * sizeof(char)];
            System.Buffer.BlockCopy(input.ToCharArray(), 0, bytes, 0, bytes.Length);

            base.Display(bytes);
        }
    }
}