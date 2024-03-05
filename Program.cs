using OpenFileProject;

var filename = FileDialog.ShowDialog("Excel Files (*.xlsx)\0*.xlsx\0");
Console.WriteLine(!string.IsNullOrEmpty(filename) ? $"Selected file: {filename}" : "No file selected.");

