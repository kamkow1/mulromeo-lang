lexer grammar LexerDefinition;

options {
    language = CSharp;
}

// values
STR_VAL             : '"' (~[\\"\r\n])* '"';
INT_VAL             : '-'? '0'..'9'+;
FLT_VAL             : '-'? ('0'..'9')+ '.' ('0'..'9')*;

// opertators
ASSIGN      : '=';
ADD         : '+';
SUB         : '-';
DIV         : '/';
MUL         : '*';
POW         : '^';
// terminator
TERMINATOR  : [ \r\n];
IDENTIFIER  : [a-zA-Z_] [a-zA-Z_0-9]*;
WHITESPACE  : [ \t]+ -> skip;