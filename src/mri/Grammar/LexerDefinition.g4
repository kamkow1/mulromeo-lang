lexer grammar LexerDefinition;

options {
    language = CSharp;
}

FUNC                : 'func';
DECLARE             : 'declare';
LOOP                : 'loop';

// values
STR_VAL             : '"' (~[\\"\r\n])* '"';
INT_VAL             : '-'? '0'..'9'+;
FLT_VAL             : '-'? ('0'..'9')+ '.' ('0'..'9')*;

// opertators
ASSIGN              : '=';
ADD                 : '+';
SUB                 : '-';
DIV                 : '/';
MUL                 : '*';
POW                 : '^';

// return types
VOID                : 'void';
INT                 : 'int';
STRING              : 'str';
FLOAT               : 'flt';

// terminator
TERMINATOR          : ';';

COMMA               : ',';
LPAREN              : '(';
RPAREN              : ')';
LBRACE              : '{';
RBRACE              : '}';
PIPE                : '|';
ARROW               : '->';
AMP                 : '&';

IDENTIFIER          : [a-zA-Z_] [a-zA-Z_0-9]*;
WHITESPACE          : [ \r\n\t]+ -> skip;