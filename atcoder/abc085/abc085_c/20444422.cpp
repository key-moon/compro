// detail: https://atcoder.jp/contests/abc085/submissions/20444422
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n;
  ll y;
  cin >> n >> y;
  for (int i = 0; i <= n; i++) {
    for (int j = 0; j <= n - i; j++) {
      var k = n - i - j;
      var res = i * 1000 + j * 5000 + k * 10000;
      if (res == y) {
        cout << k << " " << j << " " << i << endl;
        return 0;
      }
    }
  }
  cout << -1 << " " << -1 << " " << -1 << endl;
}
