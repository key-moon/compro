// detail: https://atcoder.jp/contests/abc136/submissions/20439851
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  ll prev = INT_MIN;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if (prev <= a - 1) prev = a - 1;
    else if (prev <= a) prev = a;
    else prev = INT_MAX;
  }
  cout << (prev != INT_MAX ? "Yes" : "No") << endl;
}
