// detail: https://atcoder.jp/contests/agc011/submissions/20446983
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, c, k;
  cin >> n >> c >> k;
  vector<int> t(n);
  for (int i = 0; i < n; i++) cin >> t[i];
  sort(t.begin(), t.end());
  int res = 0;
  int dep = -1;
  int space = 0;
  for (var&& elem : t) {
    if (elem <= dep && space != 0) {
      space--;
      continue;
    }
    dep = elem + k;
    space = c - 1;
    res++;
  }
  cout << res << endl;
}
