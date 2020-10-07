// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2883/judge/4895897/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 > void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 > void chmax(T1 &a, T2 b) { if (a < b) a = b; }

struct Op{
  char op;
  int a;
  int b;
  Op(char op, int a, int b):op(op), a(a), b(b){}
  int get(){
    //cout<< " " << a << " " << b << endl;
    int val = 0;
    switch (op){
    case '+':
      return a | b;
    case '*':
      return a & b;
    case '^':
      return a ^ b;
    }
    return 114514;
  }
};

int hsh(string& s, vector<int>& p){
  stack<Op> hash{};
  hash.push(Op('+', 0, -1));
  for (int i = 0; i < s.size(); i++){
    var c = s[i];
    //cout << c << endl;
    if (c == '['){
      char op = s[++i];
      hash.push(Op(op, -1, -1));
    }
    else {
      int val;
      if (c == ']'){
        val = hash.top().get(); hash.pop();
      }
      else {
	val = p[c - 'a'];
      }
      var& op = hash.top();
      if (op.a == -1) op.a = val;
      else op.b = val;
      //cout << hash.top().a << " " << hash.top().b << endl;
    }
  }
  return hash.top().get();
}

signed main() {
  while (1){
    string s;
    string p;
    cin >> s;
    if (s == ".") break;
    cin >> p;
    vector<int> v{ p[0] - '0', p[1] - '0', p[2] - '0', p[3] - '0' };
    var h = hsh(s, v);
    //return 0;
    int res = 0;
    for (int i = 0; i < 10; i++){
      for (int j = 0; j < 10; j++){
        for (int k = 0; k < 10; k++){
	  for (int l = 0; l < 10; l++){
	    vector<int> v{i,j,k,l};
	    if (h == hsh(s, v)) res++;
	  }
	}
      }
    }
      cout << h << " " << res << endl;
  }
}

