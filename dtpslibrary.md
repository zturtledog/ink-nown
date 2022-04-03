>formatting

_path_ is formated as :<head/section>.<nyble>
_head_ is formated as :<head/section>

>load / txt

.load(_path_)                  : loads from file
.loadencrypted(_key_,_path_)   : loads encrypted file
.txt(_path_)                   : loads from string
.txtencrypted(_key_,_path_)    : loads encrypted string

>get

.getraw(_path_)            : get value from path, returns a string
.getnum(_path_)            : get path as double
.getbool(_path_)           : get path as bool
.getheadasarray(_head_)    : get head as array

>compile

.startsection(_head_)          : start the section head
.insert(_nyble_,_value_)       : insert a entry into the section
.endsection()                  : close the section
.addsectionarray(_head_)       : add a section to the main with content of array
.addvarible(_name_,_value_)    : add a varible to the main
.compile()                     : compile the script and return a string with formated contents
.compileandencrypt(_key_)      : compile and encrypt

>cryptography

.cryptography.encryptstring(_key_,_value_)    : encrypt a string acording to a key
.cryptography.decryptstring(_key_,_value_)    : decrypt a string acording to a key
