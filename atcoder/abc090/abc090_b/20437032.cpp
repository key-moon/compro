// detail: https://atcoder.jp/contests/abc090/submissions/20437032
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b;
  cin >> a >> b;
  int res = 0;
  for (int i = a; i <= b; i++) {
    var s = to_string(i);
    var revs = s;
    reverse(revs.begin(), revs.end());
    if (s == revs) res++;
  }
  cout << res << endl;
}
