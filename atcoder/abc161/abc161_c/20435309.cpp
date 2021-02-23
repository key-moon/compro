// detail: https://atcoder.jp/contests/abc161/submissions/20435309
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n, k;
  cin >> n >> k;
  cout << min(n % k, k - n % k) << endl;
}
