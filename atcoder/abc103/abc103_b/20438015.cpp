// detail: https://atcoder.jp/contests/abc103/submissions/20438015
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s, t;
  cin >> s >> t;
  int n = s.size();
  for (int i = 0; i <= n + 1; i++) {
    s = s.substr(1) + s[0];
    if (s == t) {
      cout << "Yes" << endl;
      return 0;
    }
  }
  cout << "No" << endl;
}
