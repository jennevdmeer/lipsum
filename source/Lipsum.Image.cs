using System;
using System.Text;

public partial class Lipsum {
	public static string Image() { return Image(Seed.Next(160, 768)); }
	public static string Image(int size) {
		double aspect = (Seed.NextDouble() * 0.5) + 0.5;
		return Image(size, aspect);
	}
	public static string Image(int size, double aspect) {
		int width = size, height = size;

		// Larger then x percentage to get a none square image
		if (Seed.NextDouble() > 0.25) {
			// Get (random) aspectratio, random is: 0.5 (2:1) - 1 (1:1)
			height = Convert.ToInt32(size * aspect);

			// Chance to flip width/ height around if not square
			if (Seed.NextDouble() > 0.5) {
				int old = width;
				width = height;
				height = old;
			}
		}

		return Image(width, height);
	}
	public static string Image(int width, int height) { return Image(width, height, string.Empty); }
	public static string Image(int width, int height, string extra) {
		StringBuilder content = new StringBuilder();
		if (width + height > 0) {
			content.AppendLine("<img src=\"http://placehold.it/" + width + "x" + height + extra + "\" class=\"" + (Seed.NextDouble() > 0.5 ? "left" : "right") + "\" />");
			return content.ToString();
		}
		return string.Empty;
	}
}