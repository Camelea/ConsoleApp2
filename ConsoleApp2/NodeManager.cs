//using DocumentFormat.OpenXml.Packaging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Linq;
//using System.Xml.XPath;

//namespace ConsoleApp2.Tables
//{
//	internal class NodeManager
//	{
//		private string FileName { get; set; }
//		private XDocument xdoc;
//		private WordprocessingDocument doc;
//		private XmlNamespaceManager XmlNsMgr { get; set; }

//		public XNode CurrentNode { get; private set; }

//		public NodeManager(string fileName)
//		{
//			this.FileName = fileName;
//		}




//		public void LoadDocument()
//		{
//			doc = WordprocessingDocument.Open(FileName, false);
//			xdoc = doc.ToFlatOpcDocument();
//			LoadNsMgr();
//			CurrentNode = xdoc.Document.Root;

//		}

//		private void LoadNsMgr()
//		{
//			XmlNsMgr = new XmlNamespaceManager(new NameTable());
//			XmlNsMgr.AddNamespace("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
//			XmlNsMgr.AddNamespace("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
//			XmlNsMgr.AddNamespace("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
//			XmlNsMgr.AddNamespace("cx2", "http://schemas.microsoft.com/office/drawing/2015/10/21/chartex");
//			XmlNsMgr.AddNamespace("cx3", "http://schemas.microsoft.com/office/drawing/2016/5/9/chartex");
//			XmlNsMgr.AddNamespace("cx4", "http://schemas.microsoft.com/office/drawing/2016/5/10/chartex");
//			XmlNsMgr.AddNamespace("cx5", "http://schemas.microsoft.com/office/drawing/2016/5/11/chartex");
//			XmlNsMgr.AddNamespace("cx6", "http://schemas.microsoft.com/office/drawing/2016/5/12/chartex");
//			XmlNsMgr.AddNamespace("cx7", "http://schemas.microsoft.com/office/drawing/2016/5/13/chartex");
//			XmlNsMgr.AddNamespace("cx8", "http://schemas.microsoft.com/office/drawing/2016/5/14/chartex");
//			XmlNsMgr.AddNamespace("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
//			XmlNsMgr.AddNamespace("aink", "http://schemas.microsoft.com/office/drawing/2016/ink");
//			XmlNsMgr.AddNamespace("am3d", "http://schemas.microsoft.com/office/drawing/2017/model3d");
//			XmlNsMgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
//			XmlNsMgr.AddNamespace("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
//			XmlNsMgr.AddNamespace("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
//			XmlNsMgr.AddNamespace("v", "urn:schemas-microsoft-com:vml");
//			XmlNsMgr.AddNamespace("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
//			XmlNsMgr.AddNamespace("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
//			XmlNsMgr.AddNamespace("w10", "urn:schemas-microsoft-com:office:word");
//			XmlNsMgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
//			XmlNsMgr.AddNamespace("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
//			XmlNsMgr.AddNamespace("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
//			XmlNsMgr.AddNamespace("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
//			XmlNsMgr.AddNamespace("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
//			XmlNsMgr.AddNamespace("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
//			XmlNsMgr.AddNamespace("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
//			XmlNsMgr.AddNamespace("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
//			XmlNsMgr.AddNamespace("mc: Ignorable", "w14 w15 w16se wp14");
//		}

//		public Node NextNode()
//		{
//			var nextNode = CurrentNode.NextNode;
//			if (nextNode == null)
//			{
//				return null;
//			}
//			else
//			{
//				CurrentNode = nextNode;
//				return new Node(CurrentNode, XmlNsMgr);

//			}
//		}

//		public Node NextNodeWithStyle(EnumStyles style)
//		{
//			var currentNode = new Node(CurrentNode, XmlNsMgr);
//			while (currentNode != null && !currentNode.HasFollowingStyle(style))
//			{
//				currentNode = NextNode();
//			}
//			return currentNode;
//		}


//		public Node NextNodeWithElement(EnumElements element)
//		{
//			var currentNode = new Node(CurrentNode, XmlNsMgr);
//			while (currentNode != null && !currentNode.HasElement(element))
//			{
//				currentNode = NextNode();
//			}
//			return currentNode;
//		}

//		public string GetValueFromNextNodeWithStyle(EnumStyles style)
//		{
//			var currentNode = NextNodeWithStyle(style);
//			// Heading 2 - Nom Table
//			if (currentNode != null && currentNode.HasFollowingStyle(style))
//			{
//				return currentNode.GetValue();
//			}
//			return null;
//		}

//		public void XPathSelectElements(string xpath)
//		{
//			return xdoc.Document.(xpath);
//		}


//	}
//}
