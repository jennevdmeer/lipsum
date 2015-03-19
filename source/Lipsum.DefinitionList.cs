using System;
using System.Text;

public partial class Lipsum {
	public static string DefinitionList() { return DefinitionList(LipsumFormat.None); }
	public static string DefinitionList(LipsumFormat options) {
		StringBuilder content = new StringBuilder();

		content.AppendLine("<dl>");
		for (int i = Seed.Next(2, 5); i > 0; i--) {
			content.AppendLine("<dt><dfn>" + Phrase + "</dfn></dt>");
			content.AppendLine("<dd>" + Phrase + "</dd>");
		}
		content.AppendLine("</dl>");

		return content.ToString();
	}
}
