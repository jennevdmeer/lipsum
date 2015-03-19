using System;
using System.Text;

public partial class Lipsum {
	public static string UnorderedList() { return UnorderedList(LipsumFormat.None); }
	public static string UnorderedList(LipsumFormat options) {
		StringBuilder content = new StringBuilder();

		// Generate HTML block
		content.AppendLine("<ul>");
		for (int i = Seed.Next(2, 5); i > 0; i--)
			content.AppendLine("<li>" + Phrase + "</li>");
		content.AppendLine("</ul>");

		return content.ToString();
	}
}