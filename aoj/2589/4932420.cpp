// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2589/judge/4932420/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  string s;
  cin >> s;
  if (s == "#") return 0;
  int i = s.size() - 1;
  int num = s[i] == 'h' ? 0 : 90;
  i -= s[i] == 'h' ? 5 : 4;
  int den = 1;
  while (i < s.size()){
    num *= 2;
    den *= 2;
    if (s[i] == 'h'){
      num -= 90;
      i -= 5;
    }
    else{
      num += 90;
      i -= 4;
    }
  }
  while (num % 2 == 0 && den % 2 == 0){
    num /= 2;
    den /= 2;
  }
  cout << num;
  if (2 <= den) cout << "/" << den;
  cout << endl;
  main();
}

