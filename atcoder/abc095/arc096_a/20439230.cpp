// detail: https://atcoder.jp/contests/abc095/submissions/20439230
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll a, b, ab, x, y;
  cin >> a >> b >> ab >> x >> y;
  ll res = min(x, y) * min(a + b, ab + ab);
  res += max(y - x, 0LL) * min(b, ab + ab);
  res += max(x - y, 0LL) * min(a, ab + ab);
  cout << res << endl;
}
