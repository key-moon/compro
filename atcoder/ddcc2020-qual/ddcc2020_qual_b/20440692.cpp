// detail: https://atcoder.jp/contests/ddcc2020-qual/submissions/20440692
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  int n;
  cin >> n;
  vector<ll> a(n);
  for (int i = 0; i < n; i++) {
    cin >> a[i];
    a[i] *= 2;
  }
  ll half = accumulate(a.begin(), a.end(), 0LL) / 2;
  for (int i = 0; i < n; i++) {
    if (half >= a[i]) {
      half -= a[i];
      continue;
    }
    cout << min(half, a[i] - half) << endl;
    return 0;
  }
}

