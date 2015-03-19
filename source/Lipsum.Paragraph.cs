using System;
using System.Text;
using System.Web;

public partial class Lipsum {
	// Generates a paragraph based on options and the length that calls it (does not support block elements)
	public static string Paragraph() { return Paragraph(LipsumLength.Random, LipsumFormat.None); }
	public static string Paragraph(LipsumLength paragraphLength) { return Paragraph(paragraphLength, LipsumFormat.None); }
	public static string Paragraph(LipsumFormat options) { return Paragraph(LipsumLength.Random, options); }
	public static string Paragraph(LipsumLength paragraphLength, LipsumFormat options) {
		StringBuilder content = new StringBuilder();
		// Prepare paragraph length
		int length = (int)paragraphLength;
		// See if we are using LipsumLength.Random
		if (length == 0) {
			length = Seed.Next((int)LipsumLength.Tiny, (int)LipsumLength.Long);
		}
		// Apply the 20% random length thing
		length = Seed.Next(Convert.ToInt32(length * 0.8), Convert.ToInt32(length * 1.2));
		content.AppendLine("<!-- Generating a paragraph with a length of " + length + " lines -->");

		// Generate paragraph
		content.AppendLine("<p>");
		// Add lines for the length we have
		for (int j = length; j > 0; j--) {
			string phrase = Phrase;

			// Do the paragraph styling things
			if (options.HasFlag(LipsumFormat.Decorate) || options.HasFlag(LipsumFormat.All)) {
				// try <b>
				if (Seed.NextDouble() < 0.07) {
					content.Append("<b>" + phrase + "</b> ");
					continue;
				}

				// try <i>
				if (Seed.NextDouble() < 0.1) {
					content.Append("<i>" + phrase + "</i> ");
					continue;
				}

				// try <mark>
				if (Seed.NextDouble() < 0.03) {
					content.Append("<mark>" + phrase + "</mark> ");
					continue;
				}

				// try <q>
				if (Seed.NextDouble() < 0.05) {
					content.Append("<q>" + phrase + "</q> ");
					continue;
				}
			}

			if (options.HasFlag(LipsumFormat.Code) || options.HasFlag(LipsumFormat.All)) {
				// try <code>
				if (Seed.NextDouble() < 0.03) {
					content.Append("<code>" + phrase + "</code> ");
					continue;
				}

				if (Seed.NextDouble() < 0.015) {
					content.Append("<pre>" + phrase + "</pre> ");
					continue;
				}
			}

			if (options.HasFlag(LipsumFormat.Link) || options.HasFlag(LipsumFormat.All)) {
				// try <a>
				if (Seed.NextDouble() < 0.03) {
					content.Append("<a href=\"" + HttpContext.Current.Request.Url.AbsoluteUri + "\">" + phrase + "</a> ");
					continue;
				}
			}

			// if not continued append no markup line
			content.AppendLine(phrase);
		}

		// close paragraph and return string
		content.AppendLine("</p>");
		return content.ToString();
	}
}