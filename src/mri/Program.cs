using Antlr4.Runtime;

var filePath = Environment.GetCommandLineArgs()[1];
var fileContent = File.ReadAllText(filePath);

var inputStream = new AntlrInputStream(fileContent);
var lexer = new LexerDefinition(inputStream);
var commonTokenStream = new CommonTokenStream(lexer);
var parser = new ParserDefinition(commonTokenStream);

var parseContext = parser.parse();
//var visitor = new KongoVisitor();

//visitor.Visit(parseContext);