#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  cout << setprecision(15) << fixed;
  int n;
  cin >> n;
  vector<int> a(n);
  for (int i = 0; i < n; i++) {
    cin >> a[i];
  }
  double valid = 0;
  double invalid = 1e9 + 1;
  for (int iter = 0; iter < 200; iter++) {
    var mid = (valid + invalid) / 2;
    double accum = 0;
    double pickedmx = -1e9;
    double mx = 0;
    vector<double> mxs(n);
    for (int i = 0; i < n; i++) {
      accum += a[i] - mid;
      chmax(pickedmx, accum);
      chmax(mx, accum);
      mxs[i] = mx;
    }
    double res = pickedmx;
    accum = 0;
    for (int i = n - 1; i >= 0; i--) {
      accum += a[i] - mid;
      if (1 <= i) chmax(res, accum + mxs[i - 1]);
    }
    chmax(res, accum);

    if (0 <= res) valid = mid;
    else invalid = mid;
  }
  cout << valid << endl;
}
