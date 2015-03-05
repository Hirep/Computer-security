# Computer-security
How to use

 Parameters: "regime" "key path" "alphabet" "input path" "output path" 
 
 where
 
1.	"regime": type of process ('d' - decryption, 'e' - encryption)
2.	"key path": file with key
3.	"alphabet": alphabet type ('l' - latin, 'c' - cyrillic)
4.	"input path": file with text to process
5.	"output path": file to output result of process

	Key file
	
*	To perform encryption using secret phrase write first line "p". Then write key phrase.
*	To perform encryption using expression write first line "c". Then write coefficients separated by ',' (e.g. "1,-2,3" which will result 3x^2-2x+1 expression).
