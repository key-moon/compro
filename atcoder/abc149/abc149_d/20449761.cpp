// detail: https://atcoder.jp/contests/abc149/submissions/20449761
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, k;
  cin >> n >> k;
  int r, s, p;
  cin >> r >> s >> p;
  string S;
  cin >> S;
  ll res = 0;
  for (int mod = 0; mod < k; mod++) {
    int pr = 0;
    int pp = 0;
    int ps = 0;
    for (int i = mod; i < n; i += k) {
      char c = S[i];
      int mx = max(max(pr, pp), ps);
      if (c == 'r') {
        pp = max(pr, ps) + p;
        pr = mx; ps = mx;
      }
      if (c == 'p') {
        ps = max(pp, pr) + s;
        pp = mx; pr = mx;
      }
      if (c == 's') {
        pr = max(ps, pp) + r;
        ps = mx; pp = mx;
      }
    }
    res += max(max(pr, pp), ps);
  }
  cout << res << endl;
}
