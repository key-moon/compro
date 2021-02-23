// detail: https://atcoder.jp/contests/agc029/submissions/20441306
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  ll res = 0;
  int ctr = 0;
  for (var&& c : s) {
    if (c == 'B') ctr++;
    else res += ctr;
  }
  cout << res << endl;
}
