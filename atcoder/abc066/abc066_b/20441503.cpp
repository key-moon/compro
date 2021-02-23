// detail: https://atcoder.jp/contests/abc066/submissions/20441503
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
  for (int i = s.size() - 1; i >= 0; i--) {
    if (i % 2 != 0) continue;
    var a = s.substr(0, i / 2);
    var b = s.substr(i / 2, i / 2);
    if (a == b) {
      cout << i << endl;
      return 0;
    }
  }
}
