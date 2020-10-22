// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2845/judge/4933942/C++17
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
  int dep = 0;
  for (var&& c : s){
    if (c == '(') dep++;
    else if (c == ')') dep--;
    else cout << dep << endl;
  }
}

