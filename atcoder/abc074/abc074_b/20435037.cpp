// detail: https://atcoder.jp/contests/abc074/submissions/20435037
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
  int res = 0;
  for (int i = 0; i < n; i++) {
    int x;
    cin >> x;
    res += min(x, k - x) * 2;
  }
  cout << res << endl;
}
