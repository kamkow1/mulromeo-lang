using System;
using System.IO;
using Antlr4.Runtime;
using mri;

var filePath = Environment.GetCommandLineArgs()[1];
var fileContent = File.ReadAllText(filePath);

var inputStream = new AntlrInputStream(fileContent);
var lexer = new LexerDefinition(inputStream);
var commonTokenStream = new CommonTokenStream(lexer);
var parser = new ParserDefinition(commonTokenStream);

var parseContext = parser.parse();
var visitor = new AstNodeVisitor();

visitor.Visit(parseContext);