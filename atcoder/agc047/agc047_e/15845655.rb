# detail: https://atcoder.jp/contests/agc047/submissions/15845655
#!ruby -Knrzlib
require 'base64'

payload = '
puts 9394,p=?+,0,1,9,?<,_=3,m=9,3,
[p,3,5-_+=1,9]+(-59..0).map{[p,_,_,_,p,_,3,6,[p,6,6,6]*-_1,?<,6,9,m+=1,p,_,m,_]},
[p,3,5-_+=1,9]+(-59..0).map{[p,_,_,_,p,_,3,6,[p,6,6,6]*-_1,?<,6,9,m+=1,p,_,m,_]},
(-59..0).map{|a|[p,2,2,2]+(1..59+a).map{[p,99+a-_1,99+_1,_,?<,3,_,_,p,_,2,2]}}'

prologue = '#!ruby -Knrzlib
eval Zlib.inflate'

compressed = Zlib.deflate(payload.split("\n").join(""), 9)

separator = "'"

code = prologue + separator + compressed + separator

STDERR.puts code.size

if 170 < code.size then raise end
if compressed.include? separator then raise end
if compressed.include? "\r" then raise end
if code.include? "\r" then raise end

eval code
#puts Base64.strict_encode64(code)
