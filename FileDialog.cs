using System.Runtime.InteropServices;

namespace OpenFileProject;

public static class FileDialog
{
    [DllImport("comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool GetOpenFileName(ref OpenFileName ofn);

    public static string ShowDialog(string filter = "All Files (*.*)\0*.*\0", string title = "Open File")
    {
        var ofn = new OpenFileName
        {
            lStructSize = Marshal.SizeOf<OpenFileName>(),
            lpstrFilter = filter,
            lpstrFile = new string(new char[256]),
            nMaxFile = 256,
            lpstrFileTitle = new string(new char[64]),
            nMaxFileTitle = 64,
            lpstrTitle = title,
            Flags = 0x00080000 | 0x00000002 // OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST
        };

        return GetOpenFileName(ref ofn) ? ofn.lpstrFile.TrimEnd('\0') : string.Empty;
    }
}