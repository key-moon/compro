// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2252/judge/4930534/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  string l = "qwertasdfgzxcvb";
  vector<bool> b(256);
  for (var&& c : l){
    b[c] = true;
  }
  string s;
  cin >> s;
  if (s == "#") return 0;
  int res = 0;
  bool state = b[s[0]];
  for (int i = 1; i < s.size(); i++){
    var ns = b[s[i]];
    if (state != ns) res++;
    state = ns;
  }
  cout << res << endl;
  main();
}

