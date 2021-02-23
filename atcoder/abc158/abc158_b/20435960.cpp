// detail: https://atcoder.jp/contests/abc158/submissions/20435960
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n, a, b;
  cin >> n >> a >> b;
  var res = n / (a + b) * a;
  res += min(n % (a + b), a);
  cout << res << endl;
}
