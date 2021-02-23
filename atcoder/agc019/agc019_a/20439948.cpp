// detail: https://atcoder.jp/contests/agc019/submissions/20439948
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll q, h, s, d;
  cin >> q >> h >> s >> d;
  chmin(h, q + q);
  chmin(s, h + h);
  chmin(d, s + s);
  ll n;
  cin >> n;
  cout << (n / 2) * d + (n % 2) * s << endl;
}
