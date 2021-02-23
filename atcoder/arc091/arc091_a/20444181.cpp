// detail: https://atcoder.jp/contests/arc091/submissions/20444181
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n, m;
  cin >> n >> m;
  if (n > m) swap(n, m);
  if (n == 1 && m == 1) {
    cout << 1 << endl;
    return 0;
  }
  if (n == 1) {
    cout << m - 2 << endl;
    return 0;
  }
  cout << (n - 2) * (m - 2) << endl;
}
