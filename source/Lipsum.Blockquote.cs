using System;
using System.Text;
using System.Web;

public partial class Lipsum {
	public static string Blockquote() { return Blockquote(LipsumFormat.None); }
	public static string Blockquote(LipsumFormat options) {
		StringBuilder content = new StringBuilder();
		content.AppendLine("<blockquote cite=\"" + HttpContext.Current.Request.Url.AbsoluteUri + "\">" + Paragraph(options) + "</blockquote>");
		return content.ToString();
	}
}