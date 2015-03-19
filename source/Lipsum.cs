using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Windows;

/* Value is sentence length of things
 * Will vary by 20% lines in the end eg:
 * Tiny is 1.8-2.2 = 2-2 = 2
 * Short is 4.25-5.75 = 4-6
 * Medium is 8-12
 */
public enum LipsumLength {
	Random = 0,
	Single = 1,
	Tiny = 2,
	Short = 5,
	Medium = 10,
	Long = 15,
	VeryLong = 25,
	Huge = 50
}

// bitwise flags for all options that are available
[Flags]
public enum LipsumFormat {
	None = 0,
	Decorate = 1 << 0,
	Link = 1 << 1,
	OrderedList = 1 << 2,
	UnorderedList = 1 << 3,
	DefinitionList = 1 << 4,
	Blockquote = 1 << 5,
	Code = 1 << 6,
	Header = 1 << 7,
	Image = 1 << 8,
	All = 1 << 9
}

public static partial class Lipsum {
	public static List<string> Phrases = new List<string> {
			"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
			"Fusce ut orci posuere, tincidunt sem vitae, dapibus neque.",
			"Pellentesque in ex malesuada nulla malesuada mattis eu in velit.",
			"Praesent maximus velit ut volutpat ultrices.",
			"Vestibulum nec lectus eget leo bibendum euismod.",
			"Maecenas et neque eu ipsum tempor aliquet in sit amet ipsum.",
			"Etiam at urna dignissim, vestibulum nulla sit amet, accumsan justo.",
			"Nam quis lacus id libero sodales sollicitudin ac sed eros.",
			"Sed et orci vel metus bibendum efficitur.",
			"Aliquam vel massa quis eros placerat eleifend eu quis eros.",
			"Mauris vel justo ac felis rhoncus finibus.",
			"Praesent eget ligula pellentesque, efficitur turpis in, ultrices ligula.",
			"Mauris a risus sollicitudin, aliquam sem et, dignissim eros.",
			"Praesent et justo sit amet felis varius cursus sed vitae eros.",
			"Donec nec eros gravida, rhoncus urna et, facilisis massa.",
			"Sed fermentum arcu sit amet suscipit commodo.",
			"Donec sit amet lacus placerat, eleifend lacus quis, feugiat nibh.",
			"Cras a massa sagittis, commodo turpis eu, feugiat arcu.",
			"Vestibulum id libero quis justo consectetur ullamcorper.",
			"Praesent aliquet diam vel elit ultricies, nec elementum est interdum.",
			"Vivamus commodo lectus et mollis interdum.",
			"Mauris ut mauris sed nibh molestie aliquam.",
			"Fusce sollicitudin sapien vitae nibh pretium pellentesque.",
			"Fusce dapibus est ac dapibus ullamcorper.",
			"Aliquam aliquet nibh hendrerit semper rhoncus.",
			"Phasellus mollis lacus in massa ornare, nec tempus nisl dignissim.",
			"Integer vel sem ut tortor sollicitudin posuere.",
			"Etiam luctus lorem scelerisque, laoreet lorem a, laoreet elit.",
			"Nunc sagittis est eget tempus vulputate.",
			"Maecenas at urna ac ipsum molestie aliquam a id eros.",
			"Suspendisse suscipit elit nec faucibus varius.",
			"Phasellus at massa sit amet massa rhoncus tempus vitae ac velit.",
			"Maecenas porta dolor quis dolor aliquet mattis.",
			"Fusce accumsan augue a odio accumsan auctor.",
			"Integer aliquam nunc eget nibh elementum pulvinar.",
			"Etiam at est accumsan, volutpat odio in, facilisis ante.",
			"Curabitur tempus odio non purus elementum fermentum.",
			"Suspendisse vestibulum leo nec rutrum porttitor.",
			"Nam efficitur neque quis metus hendrerit pretium.",
			"Nam a dolor eget lorem semper maximus.",
			"Phasellus aliquet nisi a neque hendrerit varius.",
			"In iaculis lectus ac nibh tempor, vel porttitor lectus tristique.",
			"Phasellus sed risus blandit, scelerisque mauris at, vehicula nisi.",
			"Sed non ante accumsan, accumsan odio in, mollis ex.",
			"Pellentesque facilisis ex at urna dapibus, quis fermentum quam imperdiet.",
			"Curabitur ut augue sed tellus egestas dignissim.",
			"Suspendisse scelerisque quam efficitur ullamcorper vehicula.",
			"Phasellus sit amet nulla sit amet diam aliquet sodales et non felis.",
			"Maecenas ut risus at enim sodales aliquet et vitae nulla.",
			"Nullam quis sem eu erat semper ultrices semper ac quam.",
			"Nam sit amet velit vel tortor bibendum vulputate non ut ante.",
			"Sed at tortor vel magna mattis egestas.",
			"Curabitur pellentesque nibh non justo auctor pulvinar.",
			"In tempus dui quis accumsan ultrices.",
			"Etiam at ex sit amet neque pharetra condimentum.",
			"Proin placerat erat sed leo mollis, vel pulvinar tellus posuere.",
			"Aenean gravida enim eu dictum accumsan.",
			"Mauris et felis malesuada, ultrices lectus non, condimentum nulla.",
			"Proin et nunc sagittis, ultrices lectus nec, fermentum nibh.",
			"Suspendisse vehicula metus non augue aliquam blandit eu vitae nibh.",
			"Cras bibendum libero in magna tempus vestibulum.",
			"Ut eu odio non felis tempus ornare.",
			"Maecenas sed eros sit amet dui dictum aliquet.",
			"Nulla iaculis mauris vitae turpis tincidunt, at hendrerit ligula condimentum.",
			"Mauris viverra ante et lorem faucibus, at efficitur mauris aliquam.",
			"Sed pellentesque ante non metus facilisis, id consequat eros auctor.",
			"Vestibulum euismod massa sit amet tincidunt suscipit.",
			"Fusce commodo nisi faucibus felis fermentum consequat eu a nulla.",
			"Aenean ut est ac erat molestie vulputate.",
			"Curabitur posuere turpis at massa dictum, eget volutpat metus pharetra.",
			"Suspendisse finibus odio nec sapien condimentum pellentesque.",
			"Donec tristique est et risus auctor, eu cursus magna euismod.",
			"Cras facilisis tortor eget felis condimentum, id tristique nisl imperdiet.",
			"Curabitur sit amet sapien at neque efficitur facilisis.",
			"Aenean dictum massa a eleifend sagittis.",
			"Suspendisse elementum ligula eget vehicula vulputate.",
			"Proin non ipsum ultricies, sagittis odio nec, tempor felis.",
			"Fusce ut magna commodo, interdum velit feugiat, laoreet ligula.",
			"Etiam nec tellus ultrices, porta neque varius, feugiat felis.",
			"Maecenas ultricies ante ac purus facilisis, non ultrices nulla iaculis.",
			"Vestibulum nec augue in ligula consectetur interdum.",
			"Integer at erat eu purus sollicitudin pharetra non egestas lectus.",
			"Proin interdum lacus vel pulvinar mattis.",
			"Nulla non mi dictum, laoreet magna nec, aliquam massa.",
			"Cras congue tellus vitae gravida auctor.",
			"Nullam fermentum magna sed sollicitudin tempus.",
			"Sed aliquam enim nec enim ultricies fermentum.",
			"Mauris vel turpis eu ante congue ultrices in a magna.",
			"Vivamus sollicitudin odio nec magna laoreet volutpat.",
			"Mauris sollicitudin nibh a tincidunt rutrum.",
			"Proin et odio a tortor molestie convallis vel eget nibh.",
			"Sed gravida mauris non lobortis cursus.",
			"Phasellus sed magna bibendum, consequat tortor et, pharetra velit.",
			"Etiam efficitur tellus rutrum nibh efficitur, eget imperdiet leo scelerisque.",
			"Integer ut erat sit amet neque tempus pulvinar ac vitae nisl.",
			"Integer laoreet ex pellentesque metus aliquet, a posuere nulla sollicitudin.",
			"Nullam placerat ligula sagittis, laoreet tellus vel, lobortis mi.",
			"Sed venenatis sem vel placerat scelerisque.",
			"Curabitur et dui sed ipsum semper aliquam.",
			"Vestibulum malesuada mi et ex malesuada iaculis.",
			"Morbi et mi efficitur, feugiat orci at, pulvinar risus.",
			"Maecenas molestie magna at risus suscipit elementum.",
			"Phasellus varius risus ac diam scelerisque consequat.",
			"Fusce feugiat nisi sit amet leo pharetra, a condimentum nulla cursus.",
			"Praesent non orci posuere, molestie dui nec, pellentesque eros.",
			"Morbi a nibh non erat aliquet feugiat vel laoreet lectus.",
			"Donec fringilla leo pharetra ex viverra, in efficitur arcu tempor.",
			"Sed porta augue in dolor iaculis vulputate.",
			"Etiam efficitur turpis sit amet augue congue posuere.",
			"Suspendisse venenatis odio nec blandit porttitor.",
			"Duis tempor ex nec massa luctus porttitor.",
			"Mauris eleifend orci sit amet ante mollis ultrices id eu tortor.",
			"Integer tempus mauris at lacus eleifend, at tristique massa porttitor.",
			"Donec sagittis risus et rhoncus aliquam.",
			"Curabitur fringilla sapien at augue interdum, eget feugiat elit posuere.",
			"Integer ac arcu auctor, laoreet magna eu, volutpat elit.",
			"Vivamus pellentesque lorem non purus rhoncus dictum.",
			"Mauris vitae metus et ligula suscipit rutrum eget ut nulla.",
			"Integer vitae nisl interdum, cursus turpis ut, venenatis lorem.",
			"Suspendisse at lorem ullamcorper, vestibulum nisl a, condimentum arcu.",
			"Morbi viverra magna ullamcorper, sagittis ligula non, euismod ipsum.",
			"Fusce tincidunt velit eget luctus ultrices.",
			"Duis cursus diam cursus nisi rhoncus, a sodales magna euismod.",
			"Donec at neque quis tellus posuere pretium.",
			"Aenean tincidunt ipsum vitae venenatis tristique.",
			"In sollicitudin enim id diam tristique pharetra.",
			"Quisque ut turpis cursus, facilisis lorem in, fringilla dui.",
			"Aenean aliquet tellus ut feugiat ultrices.",
			"Nulla faucibus turpis vel ipsum commodo, nec malesuada odio eleifend.",
			"Donec faucibus leo in sapien auctor, eget vestibulum lorem aliquam.",
			"Vivamus sit amet lacus volutpat lacus hendrerit euismod.",
			"Vestibulum sed neque congue, dignissim erat ut, porttitor massa.",
			"Aenean vitae libero a neque blandit lacinia.",
			"Proin pulvinar nunc vel diam venenatis commodo.",
			"Nam fringilla mauris tincidunt pellentesque sollicitudin.",
			"Nullam vel enim vel urna volutpat pellentesque.",
			"Nam varius diam eu fringilla placerat.",
			"Integer nec mauris ut lacus sagittis vehicula.",
			"Aenean tempus lectus at ipsum semper, ut sagittis neque accumsan.",
			"Integer egestas nisi vitae venenatis fringilla.",
			"Aliquam sed justo ac elit tristique euismod vitae ornare eros.",
			"Ut eu nunc ornare, maximus elit vitae, tempus turpis.",
			"Mauris pellentesque ante non laoreet condimentum.",
			"Integer vel neque sodales, ullamcorper purus ac, dictum nisl.",
			"Morbi sollicitudin urna egestas sapien auctor faucibus.",
			"Nam posuere elit nec sem tincidunt, eu dignissim magna ornare.",
			"Sed ut mauris vitae quam tincidunt aliquet id at nulla.",
			"Donec ullamcorper ex id odio fringilla maximus.",
			"Mauris vestibulum justo feugiat nunc consectetur aliquet.",
			"Aliquam commodo massa a lorem placerat eleifend.",
			"Ut ornare nibh id tincidunt sagittis.",
			"Nam in erat gravida, auctor sem ac, facilisis eros.",
			"Nunc sed odio eu felis lacinia dapibus nec sed neque.",
			"Etiam sed turpis ut felis viverra rutrum.",
			"Integer non dolor id tortor vulputate tincidunt.",
			"Integer sit amet orci ac arcu luctus semper.",
			"Nullam sed lectus dignissim, porta felis sit amet, porta mauris.",
			"Etiam in sapien vitae eros pretium pretium.",
			"Donec in mauris finibus, accumsan justo at, congue nisl.",
			"Praesent id massa eu eros congue cursus.",
			"Nunc nec quam ut enim posuere imperdiet vel rutrum nunc.",
			"Ut nec lacus non neque pellentesque finibus.",
			"Proin mattis risus eu turpis mollis tincidunt.",
			"Suspendisse vel sem id nisl finibus dignissim non vitae justo.",
			"Nulla vestibulum quam vel semper viverra.",
			"Pellentesque quis urna eu tellus auctor mollis.",
			"Aliquam aliquam justo a congue tincidunt.",
			"Praesent tristique orci efficitur felis facilisis, sit amet vestibulum purus tincidunt.",
			"Curabitur dictum turpis eu mauris tempor, et porttitor lorem luctus.",
			"Cras in velit aliquam, aliquam lacus non, pellentesque ex.",
			"Duis consectetur erat non bibendum finibus.",
			"Praesent vitae turpis imperdiet, aliquam arcu id, aliquam elit.",
			"Curabitur commodo lacus sit amet magna scelerisque varius.",
			"Nullam sodales mi a libero accumsan consequat.",
			"Praesent a sem nec massa ultrices finibus.",
			"Cras vitae dolor sed risus sollicitudin luctus.",
			"Fusce ac arcu eu orci porta auctor eu vitae ipsum.",
			"In ut nulla ullamcorper, mollis nibh non, tempus diam.",
			"Vivamus gravida est id ex luctus, sed rhoncus diam eleifend.",
			"Donec sodales tortor et est consequat, quis venenatis ante consequat.",
			"Pellentesque a justo porttitor, sollicitudin justo sit amet, dictum est.",
			"Sed quis ante et quam euismod iaculis.",
			"Nullam non sem imperdiet, viverra arcu eget, eleifend nunc.",
			"Vestibulum sagittis sem at metus vehicula, eu eleifend ante ultricies.",
			"Proin eget tellus sit amet orci aliquam fringilla.",
			"Donec vitae mauris malesuada, molestie massa vitae, facilisis urna.",
			"Duis nec magna quis nisl accumsan tincidunt.",
			"Praesent facilisis lacus et fringilla ultricies.",
			"Donec malesuada eros et velit volutpat sodales.",
			"Vestibulum vel sapien sit amet mauris mattis dignissim.",
			"Phasellus congue nisl eu quam venenatis luctus.",
			"Donec at tellus scelerisque, cursus massa at, scelerisque tortor.",
			"Aenean id enim gravida, volutpat nisl eget, convallis nulla.",
			"Morbi bibendum nisi vitae erat porta, vitae aliquet arcu porta.",
			"Morbi cursus mi sed aliquet tincidunt.",
			"Maecenas porta felis et augue sollicitudin congue.",
			"Aliquam in eros id ex ultricies tempus.",
			"Ut sit amet mauris et dolor fermentum sodales non a velit.",
			"Proin quis dolor non est lobortis feugiat.",
			"Curabitur accumsan odio dignissim bibendum egestas.",
			"Nam at odio aliquet, ultricies ipsum nec, malesuada metus.",
			"Duis sit amet felis non nisi sagittis dapibus vel ac dolor.",
			"Pellentesque eu augue condimentum urna ultricies molestie.",
			"Maecenas venenatis diam et nunc ullamcorper sagittis.",
			"Quisque sollicitudin velit sed quam gravida fermentum.",
			"Nullam condimentum eros vel rhoncus congue.",
			"Donec rutrum libero vel pulvinar sollicitudin.",
			"Donec pharetra ligula in metus tincidunt tempor.",
			"Cras ac mi eu elit laoreet faucibus sit amet in neque.",
			"Sed mattis ipsum id mi commodo, quis pharetra dolor mattis.",
			"Phasellus condimentum justo ut vehicula ultricies.",
			"Suspendisse et turpis et dolor dignissim lacinia.",
			"Nam facilisis dui ullamcorper urna rhoncus, eget bibendum mi ultricies.",
			"Sed a mi finibus, varius justo eu, faucibus odio.",
			"Sed non massa in nulla placerat egestas rhoncus ac ex.",
			"Vestibulum vitae tortor elementum, vestibulum tellus viverra, pharetra est.",
			"Nunc sollicitudin tellus ac elit interdum volutpat.",
			"Sed ac neque imperdiet metus tristique imperdiet.",
			"Vestibulum accumsan erat ut auctor suscipit.",
			"Nulla in tortor vestibulum, porttitor mauris sit amet, feugiat enim.",
			"Integer sollicitudin ante id pharetra porta.",
			"Nunc a risus malesuada, porttitor diam accumsan, fermentum risus.",
			"Duis luctus metus vel diam pharetra condimentum.",
			"Nunc sit amet dui ac massa facilisis dictum.",
			"Vestibulum eu est sollicitudin, finibus augue vitae, facilisis massa.",
			"Sed vulputate ipsum sit amet odio aliquet bibendum.",
			"Fusce ac lectus vel augue malesuada condimentum.",
			"Donec quis massa sollicitudin, facilisis nisi sed, ultrices ante.",
			"Cras vitae mauris eu erat ullamcorper vestibulum eu ut magna.",
			"Donec non ligula cursus, mattis ipsum sed, sollicitudin arcu.",
			"Phasellus tempor magna nec augue molestie venenatis a ut sem.",
			"Duis feugiat nibh vehicula nibh dictum, sit amet dignissim urna porta.",
			"Sed mollis risus eget pharetra maximus.",
			"Cras non nisi porta, blandit elit non, vulputate ligula.",
			"Donec at turpis eget turpis eleifend malesuada sit amet sit amet diam.",
			"Integer lobortis ex id pellentesque dignissim.",
			"Sed non elit elementum, vulputate odio laoreet, pharetra nisi.",
			"Aenean semper velit ut erat rhoncus iaculis.",
			"Suspendisse lacinia eros at est convallis, mattis suscipit lacus finibus.",
			"Proin fermentum turpis ac eros pretium, euismod suscipit lorem suscipit.",
			"Vivamus aliquet est in erat sagittis, at molestie dolor lacinia.",
			"Integer efficitur orci sit amet mauris gravida laoreet ut quis ante.",
			"In a turpis eu lacus bibendum mollis.",
			"Cras lacinia augue iaculis cursus iaculis.",
			"Ut vulputate nulla nec volutpat consectetur.",
			"Aenean sagittis diam a nisi maximus, sed malesuada sem interdum.",
			"Phasellus ac metus lacinia, elementum neque et, ornare dolor.",
			"In nec nisl sit amet orci accumsan volutpat.",
			"Aenean pharetra dui ac enim tempus, auctor porttitor lectus sodales.",
			"Curabitur ultrices tortor ut auctor maximus.",
			"Donec sed velit a lorem finibus hendrerit.",
			"Etiam egestas lorem sodales, efficitur arcu id, vestibulum erat.",
			"Aenean dapibus ex id nibh imperdiet venenatis.",
			"Maecenas scelerisque libero ac libero consequat efficitur.",
			"Duis vehicula libero a magna eleifend, ac ultrices est tristique.",
			"Vestibulum id risus porta, mattis velit a, fringilla ligula.",
			"Sed suscipit nisl ac maximus malesuada.",
			"Donec non lorem feugiat, cursus nunc sed, scelerisque nisi.",
			"Pellentesque aliquet libero sed nisl facilisis semper.",
			"Duis pretium nunc quis venenatis rutrum.",
			"Duis eget lectus id risus semper condimentum.",
			"Pellentesque vel justo lobortis, porttitor nunc in, placerat felis.",
			"Donec fermentum lacus ut interdum lacinia.",
			"Suspendisse eget mauris placerat, imperdiet mauris et, ullamcorper ipsum.",
			"Curabitur congue enim et orci eleifend tempus.",
			"Praesent eu lectus tristique, bibendum nisl sit amet, dictum mi.",
			"Phasellus a velit lacinia, dignissim est eu, commodo mi.",
			"Sed gravida enim non pretium tincidunt.",
			"Donec posuere enim quis neque pellentesque, consequat iaculis ex sollicitudin.",
			"Fusce accumsan elit sed leo tincidunt, quis dapibus tortor venenatis.",
			"Nulla egestas orci ultricies erat egestas blandit.",
			"Pellentesque eu leo viverra, suscipit nibh ut, tempus libero.",
			"Nunc finibus metus eu dolor vulputate, nec commodo nulla vehicula.",
			"Proin quis ligula sit amet ante pharetra interdum.",
			"In maximus arcu non quam fringilla, non bibendum lectus convallis.",
			"Duis a lectus eu odio maximus maximus.",
			"Ut rhoncus libero non volutpat sodales.",
			"Aliquam eleifend orci vitae lacus venenatis congue.",
			"Cras a augue ut sapien sollicitudin finibus.",
			"Fusce rutrum elit a erat commodo sagittis.",
			"Aenean sollicitudin dui in est pharetra sagittis.",
			"Nunc nec ex eu tellus molestie volutpat.",
			"In tristique dolor ut lorem maximus auctor.",
			"Aenean consequat neque sit amet aliquam aliquet.",
			"Praesent porttitor orci at enim rhoncus, vel tempor lectus dapibus.",
			"Donec rutrum ante at est tempor malesuada.",
			"Proin elementum metus ut fermentum molestie.",
			"Cras convallis purus eu eros consequat aliquet.",
			"Aliquam faucibus leo aliquet massa hendrerit, id volutpat est ultricies.",
			"Nam sed augue feugiat, viverra ligula id, imperdiet felis.",
			"Integer venenatis nunc vitae enim molestie, a aliquet nunc eleifend.",
			"In ullamcorper sapien eget metus laoreet pharetra quis id turpis.",
			"Donec iaculis nibh quis dignissim pretium.",
			"Integer nec quam vitae nisl vulputate porta.",
			"Pellentesque a est ultrices, semper neque eu, varius nibh.",
			"Mauris eu metus et ex vehicula ornare.",
			"Sed vitae leo vitae dui convallis aliquet.",
			"Sed quis mauris id est dapibus maximus et sed est.",
			"Donec luctus augue at euismod tincidunt.",
			"Ut auctor sem ac laoreet eleifend.",
			"Maecenas sit amet libero interdum ipsum euismod maximus.",
			"Praesent finibus odio a est cursus, ac dapibus felis rutrum.",
			"Donec et mi quis orci euismod rhoncus vel a massa.",
			"Aliquam venenatis sem eu lacinia pharetra.",
			"In aliquam tellus nec elit pharetra commodo.",
			"Aliquam varius orci sollicitudin lorem volutpat iaculis.",
			"Mauris nec nunc eu ex pellentesque hendrerit.",
			"Aenean luctus ante nec tortor laoreet consectetur.",
			"Nunc consectetur ex quis tincidunt porttitor.",
			"Nam congue dolor luctus purus tristique venenatis.",
			"Suspendisse quis ipsum accumsan, feugiat elit sit amet, ultricies risus.",
			"Aliquam scelerisque urna sit amet pulvinar eleifend.",
			"Maecenas a nunc vel nibh tincidunt finibus.",
			"Sed cursus purus ac scelerisque rhoncus.",
			"Nulla ullamcorper leo ac neque tristique ultrices.",
			"Maecenas tincidunt mauris id diam feugiat, vel porta augue bibendum.",
			"Suspendisse eleifend leo eget maximus iaculis.",
			"Vivamus mattis felis eget euismod efficitur.",
			"Aliquam a ipsum eu ipsum pellentesque interdum vel vel neque.",
			"Cras tempor augue et placerat viverra.",
			"Nulla egestas ex non auctor egestas.",
			"Duis pretium libero vitae elit pellentesque rutrum.",
			"Aliquam at magna ullamcorper, iaculis tortor sed, tincidunt nunc.",
			"Vestibulum scelerisque diam sed consequat laoreet.",
			"Cras non libero nec dui tincidunt porta.",
			"Nam venenatis massa id lacus sagittis, sed porta purus dignissim.",
			"Morbi facilisis nisi id egestas dignissim.",
			"Sed varius est sed tellus sollicitudin eleifend.",
			"Pellentesque tincidunt nulla in felis tempus, eu cursus orci porttitor.",
			"Morbi maximus eros non dignissim ultrices.",
			"Nulla ornare mauris accumsan magna interdum consequat.",
			"Cras eu erat et leo placerat elementum vitae non velit.",
			"Nam ac felis sit amet nisi rhoncus euismod nec sit amet risus.",
			"Morbi vitae enim vehicula, blandit purus vitae, aliquet lorem.",
			"Aliquam quis urna vel nibh viverra mollis id a urna.",
			"Ut at nulla vel lectus ultrices volutpat sed quis tortor.",
			"Phasellus pellentesque nisl ut dolor pellentesque semper in a velit.",
			"Etiam ultrices diam et metus ornare, et cursus nibh interdum.",
			"Quisque id lorem quis dolor lobortis porttitor.",
			"Morbi pretium quam nec eros euismod, ut varius felis tincidunt.",
			"Nunc nec ex nec erat facilisis placerat.",
			"Sed posuere quam nec pulvinar cursus.",
			"Nulla porta dui a lacus vestibulum tristique.",
			"Aenean lobortis elit eget urna lobortis aliquam.",
			"Sed ultricies ex id dolor posuere, vitae sollicitudin odio ornare.",
			"Etiam in ligula convallis, molestie ipsum eu, vehicula tortor.",
			"Integer blandit libero vel sapien ultricies, blandit tincidunt neque tincidunt.",
			"Aliquam et lacus blandit, bibendum libero et, consequat ante.",
			"Curabitur et leo tincidunt, accumsan erat ultrices, tempus arcu.",
			"Aenean lobortis augue vitae convallis tempus.",
			"Maecenas nec magna tincidunt, blandit dolor nec, sollicitudin felis.",
			"Suspendisse eleifend nisl nec eros tempus aliquet.",
			"Sed dapibus purus eget ipsum gravida varius ut a diam.",
			"Pellentesque maximus risus eget dolor luctus lobortis.",
			"Sed eget sapien pellentesque, rhoncus nunc eget, tincidunt libero.",
			"Sed vulputate arcu nec mauris vulputate accumsan.",
			"Sed tristique neque et tellus finibus, vehicula fringilla felis varius.",
			"Duis hendrerit tortor sed cursus posuere.",
			"Fusce quis nibh quis sapien ornare convallis eu ut odio.",
			"Cras facilisis magna non magna hendrerit, quis rhoncus lectus tincidunt.",
			"Integer convallis mauris sed pharetra convallis.",
			"Nullam a felis a ligula ullamcorper faucibus.",
			"Quisque faucibus ligula non elit ullamcorper tempus.",
			"Nulla eu ex a enim placerat tincidunt.",
			"Praesent ut purus quis ligula pulvinar porta ac vel eros.",
			"Praesent auctor sem sed consectetur tincidunt.",
			"In tempus lectus sed quam pulvinar sagittis.",
			"Cras hendrerit neque id est tristique dignissim.",
			"Mauris congue justo quis sem luctus bibendum.",
			"Mauris blandit nunc consequat enim ultrices sodales.",
			"Ut porta urna elementum, pulvinar justo vulputate, egestas lacus.",
			"Nunc sit amet dolor fringilla ex tempus porttitor ut in ante.",
			"Donec vitae lacus in ante mollis blandit nec vitae dui.",
			"Suspendisse nec neque ac lacus ultrices efficitur.",
			"Nullam vehicula felis a est mattis, eget vestibulum mauris consectetur.",
			"Nam lobortis lacus non sapien pellentesque, viverra hendrerit nunc faucibus.",
			"Fusce nec tellus bibendum, volutpat nunc et, accumsan sem.",
			"Pellentesque mollis lectus nec lacus mollis placerat.",
			"Praesent volutpat nisl in dui ullamcorper mattis.",
			"Curabitur faucibus augue in massa vehicula vehicula.",
			"Pellentesque gravida ante at aliquam condimentum.",
			"Curabitur mollis lectus scelerisque convallis commodo.",
			"Morbi finibus sem sit amet ullamcorper condimentum.",
			"Nunc lacinia mauris sit amet dictum euismod.",
			"Sed blandit magna vitae dolor consequat, nec volutpat libero semper.",
			"Ut nec nisi vel neque rutrum sodales rutrum vitae arcu.",
			"Sed laoreet risus sed luctus pellentesque.",
			"Aliquam vulputate ex vel risus ultrices porta.",
			"Nulla ac nisi maximus nisl dignissim bibendum.",
			"Donec eget augue quis ante aliquet dictum.",
			"Cras semper sem sit amet bibendum consequat.",
			"Donec eu ex semper, commodo augue ut, molestie enim.",
			"Integer eu leo sit amet nibh malesuada varius.",
			"Sed non risus tincidunt, sollicitudin nulla non, laoreet dui.",
			"Duis malesuada nulla et dictum ornare.",
			"Fusce feugiat arcu commodo congue interdum.",
			"Mauris sit amet eros hendrerit, pharetra risus ut, fermentum metus.",
			"Suspendisse molestie sem aliquam purus ornare vulputate.",
			"Vestibulum id diam et augue ultrices porttitor ut vel odio.",
			"Phasellus sed augue nec orci gravida tincidunt.",
			"Donec quis justo vel ante placerat euismod.",
			"Mauris et lacus laoreet, pulvinar sem et, vestibulum lacus.",
			"Quisque nec est vel purus imperdiet tincidunt a sed sapien.",
			"Mauris vel leo sit amet eros dapibus feugiat in in felis.",
			"Praesent vestibulum ex non imperdiet mollis.",
			"Cras at lacus pellentesque, vulputate ex a, laoreet nisi.",
			"Suspendisse mollis ante lobortis fringilla congue.",
			"Cras vehicula augue efficitur faucibus tempus.",
			"Vivamus tristique nibh aliquet bibendum rutrum.",
			"Etiam sit amet purus gravida, aliquet diam vitae, pellentesque leo.",
			"Donec quis purus vel urna pretium dignissim.",
			"Integer consequat erat at fermentum facilisis.",
			"Cras vehicula purus in odio malesuada semper.",
			"Nunc fringilla orci sit amet mauris vulputate faucibus.",
			"Integer egestas sem eu tempor molestie.",
			"In faucibus sem eget pretium rhoncus.",
			"Morbi dictum est finibus, consequat quam sit amet, ultricies metus.",
			"Nunc vitae diam congue, pellentesque velit eget, tristique orci.",
			"Vestibulum ac elit porta, volutpat dui at, commodo quam.",
			"Curabitur commodo tortor vitae laoreet placerat.",
			"Ut malesuada risus quis sollicitudin aliquam.",
			"Mauris id est scelerisque, auctor nulla eu, consectetur arcu.",
			"Etiam porta ex consequat, mattis nisi non, fringilla lacus.",
			"Pellentesque sollicitudin quam vel orci ornare tincidunt.",
			"Donec condimentum nunc eu erat pulvinar, eget maximus felis accumsan.",
			"Phasellus ut mauris efficitur, accumsan nisi id, pharetra nulla.",
			"Pellentesque bibendum nisi porta sapien tempor, at tempus lorem tempor.",
			"Sed in ex placerat, efficitur metus ac, luctus est.",
			"Donec in est efficitur, tristique nunc non, tristique tortor.",
			"Aliquam vel neque molestie, accumsan sapien id, convallis tellus.",
			"Aliquam vel erat luctus, bibendum nulla quis, ultrices sem.",
			"Nam imperdiet nibh vitae euismod ornare.",
			"Aenean at lorem porttitor, ultricies neque at, feugiat felis.",
			"In at nibh ut augue iaculis eleifend sit amet sit amet nibh.",
			"Nunc congue sapien quis congue dictum.",
			"Mauris in nunc vel tellus consectetur aliquet at a tortor.",
			"Maecenas tempus erat id semper dignissim.",
			"Phasellus eu nisl nec risus ultrices feugiat.",
			"Pellentesque ullamcorper tellus suscipit, rhoncus odio eu, fringilla mauris.",
			"Vivamus sodales lorem quis consequat pretium.",
			"Praesent hendrerit magna eu felis dignissim, ut congue tortor imperdiet.",
			"Donec at ex et ipsum eleifend rutrum ac gravida tortor.",
			"Praesent consectetur libero at commodo accumsan.",
			"Donec et dolor pretium, feugiat purus quis, imperdiet ipsum.",
			"Integer lobortis est eget pulvinar varius.",
			"Phasellus non felis consectetur, sagittis eros vitae, cursus metus.",
			"Curabitur tempor quam quis nunc fermentum, convallis molestie velit efficitur.",
			"Nunc mattis turpis et convallis bibendum.",
			"Vivamus lacinia est eget odio tempus, nec cursus dui blandit.",
			"Quisque quis metus non nunc dignissim pretium.",
			"Proin egestas justo nec risus euismod, pharetra consequat nibh congue.",
			"Curabitur pharetra nibh in justo pulvinar placerat.",
			"Vestibulum tincidunt lorem in enim vestibulum, at suscipit ex maximus.",
			"Aenean feugiat lectus vitae enim euismod vestibulum sed ut eros.",
			"Duis ac metus nec augue hendrerit aliquet.",
			"Cras eget metus ut purus accumsan viverra.",
			"Phasellus vestibulum diam non nisi vehicula, at euismod ex viverra.",
			"Duis egestas arcu quis lorem rhoncus faucibus.",
			"Integer at mi nec purus rutrum interdum eu eu metus.",
			"Cras suscipit elit nec luctus aliquam.",
			"Fusce tempus felis quis metus tempor varius.",
			"Duis a neque at enim malesuada convallis vehicula a metus.",
			"Aliquam scelerisque purus sit amet nibh pretium malesuada.",
			"Aliquam vel velit vitae nisl pharetra pellentesque.",
			"Duis auctor justo vel est tempor, vel viverra dui eleifend.",
			"Nullam porta nisi a mauris malesuada, et faucibus mauris ullamcorper.",
			"Vivamus vitae velit suscipit, hendrerit ipsum quis, ultrices nibh.",
			"Nulla imperdiet felis at odio vulputate, ac posuere nulla vestibulum.",
			"Donec at tellus nec neque facilisis venenatis a vitae ex.",
			"Donec convallis dui eu eros pellentesque, vel convallis diam tristique.",
			"Etiam viverra ligula et auctor efficitur.",
			"Proin at erat tincidunt, tristique mauris eget, interdum mi.",
			"In ut diam venenatis, convallis purus quis, lobortis ligula.",
			"Ut id nisi ut mi lacinia fermentum quis ut nisi.",
			"Maecenas aliquet urna id est viverra, non convallis velit scelerisque.",
			"Mauris volutpat lectus ac quam pulvinar, quis faucibus sem posuere.",
			"In scelerisque risus at tortor dictum molestie.",
			"Sed consequat enim quis neque interdum facilisis.",
			"Vestibulum suscipit felis vitae nisl rhoncus, finibus vehicula elit pharetra.",
			"Curabitur fringilla sem nec laoreet hendrerit.",
			"Nunc non nulla sagittis, ultricies eros non, commodo lorem.",
			"Phasellus in metus vel orci consequat venenatis.",
			"Nunc consequat nunc ut elementum egestas.",
			"Pellentesque vel leo ut nisi facilisis ornare tempor nec quam.",
			"Maecenas vitae quam vitae risus sollicitudin faucibus ut ut neque.",
			"Nam pulvinar metus at odio scelerisque, pretium pharetra ante ornare.",
			"Vestibulum non tortor ac sapien interdum venenatis eu ut nibh.",
			"Duis vitae mi sagittis, sodales arcu id, egestas nisl.",
			"Donec commodo sapien id consectetur euismod.",
			"Cras et lectus scelerisque, ullamcorper lorem eget, maximus sem.",
			"Vivamus mattis tortor in tellus commodo vulputate.",
			"Proin sed dolor at velit egestas aliquet.",
			"Quisque condimentum diam tristique, condimentum dui dignissim, ultricies diam.",
			"Morbi tempus orci sit amet suscipit finibus.",
			"Nulla nec lectus at nibh pretium tincidunt.",
			"Proin accumsan urna tempor euismod ultrices.",
			"Morbi tempor enim vitae magna blandit, at blandit enim molestie.",
			"Ut rutrum ante egestas dolor pulvinar, at fringilla diam congue.",
			"Praesent et neque in massa tincidunt posuere.",
			"Morbi sit amet odio facilisis, blandit arcu quis, accumsan est."
		};

	private static Random Seed = new Random(Phrases.Count);

	private static bool _loremFirst = true;
	public static string Phrase {
		get {
			if (_loremFirst) {
				_loremFirst = false;
				return Phrases[0];
			}
			return Phrases[Seed.Next(Phrases.Count)];
		}
	}

	public static LipsumFormat DefaultOptions = LipsumFormat.Decorate;

	public static string Get() { return Get(Seed.Next(3, 5)); }
	public static string Get(int paragraphCount) { return Get(paragraphCount, LipsumLength.Random); }
	public static string Get(int paragraphCount, LipsumLength paragraphLength) { return Get(paragraphCount, paragraphLength, DefaultOptions); }
	public static string Get(int paragraphCount, LipsumLength paragraphLength, LipsumFormat options) {
		StringBuilder content = new StringBuilder();
		Dictionary<LipsumFormat, int> counter = new Dictionary<LipsumFormat, int> {
				{ LipsumFormat.Decorate, 0 },
				{ LipsumFormat.Link, 0 },
				{ LipsumFormat.OrderedList, 0 },
				{ LipsumFormat.UnorderedList, 0 },
				{ LipsumFormat.DefinitionList, 0 },
				{ LipsumFormat.Blockquote, 0 },
				{ LipsumFormat.Code, 0 },
				{ LipsumFormat.Header, 0 },
				{ LipsumFormat.Image, 0 }
			};

		// Generate paragraphs
		for (int i = 1; i <= paragraphCount; i++) {
			// If we are adding headers, add the H1
			if (options.HasFlag(LipsumFormat.Header) || options.HasFlag(LipsumFormat.All)) {
				// Always add the H1 on above the first paragraph
				if (i == 1) {
					content.AppendLine(Header(1, options));
					counter[LipsumFormat.Header]++;
				} else if (Seed.NextDouble() > 0.15) { // Generate H2-6 above paragraph
					content.AppendLine(Header(options));
					counter[LipsumFormat.Header]++;
				}
			}

			// append paragraph
			content.AppendLine(Paragraph(paragraphLength, options));

			// seed double * 100 == percent chance to trigger
			if (options.HasFlag(LipsumFormat.Blockquote) || options.HasFlag(LipsumFormat.All)) {
				if (Seed.NextDouble() < 0.1) {
					content.AppendLine(Blockquote(options));
					counter[LipsumFormat.Blockquote]++;
				}

				if ((i == paragraphCount) && (counter[LipsumFormat.Blockquote] == 0)) {
					content.AppendLine(Blockquote(options));
					counter[LipsumFormat.Blockquote]++;
				}
			}

			if (options.HasFlag(LipsumFormat.DefinitionList) || options.HasFlag(LipsumFormat.All)) {
				if (Seed.NextDouble() < 0.05) {
					content.AppendLine(DefinitionList(options));
					counter[LipsumFormat.DefinitionList]++;
				}

				if ((i == paragraphCount) && (counter[LipsumFormat.DefinitionList] == 0)) {
					content.AppendLine(DefinitionList(options));
					counter[LipsumFormat.DefinitionList]++;
				}
			}

			if (options.HasFlag(LipsumFormat.OrderedList) || options.HasFlag(LipsumFormat.All)) {
				if (Seed.NextDouble() < 0.075) {
					content.AppendLine(OrderedList(options));
					counter[LipsumFormat.OrderedList]++;
				}

				if ((i == paragraphCount) && (counter[LipsumFormat.OrderedList] == 0)) {
					content.AppendLine(OrderedList(options));
					counter[LipsumFormat.OrderedList]++;
				}
			}

			// Generate lists
			if (options.HasFlag(LipsumFormat.UnorderedList) || options.HasFlag(LipsumFormat.All)) {
				if (Seed.NextDouble() < 0.075) {
					content.AppendLine(UnorderedList(options));
					counter[LipsumFormat.UnorderedList]++;
				}

				if ((i == paragraphCount) && (counter[LipsumFormat.UnorderedList] == 0)) {
					content.AppendLine(UnorderedList(options));
					counter[LipsumFormat.UnorderedList]++;
				}
			}

			// Generate images
			if (options.HasFlag(LipsumFormat.Image) || options.HasFlag(LipsumFormat.All)) {
				if (Seed.NextDouble() < 0.2) {
					content.AppendLine(Image());
					counter[LipsumFormat.Image]++;
				}

				if ((i == paragraphCount) && (counter[LipsumFormat.Image] == 0)) {
					content.AppendLine(Image());
					counter[LipsumFormat.Image]++;
				}
			}
		}

		return content.ToString();
	}
}