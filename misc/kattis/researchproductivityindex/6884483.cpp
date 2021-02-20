#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  cout << setprecision(15);
  int n;
  cin >> n;
  vector<double> p(n);
  for (int i = 0; i < n; i++) {
    cin >> p[i];
    p[i] /= 100.0;
  }
  sort(p.begin(), p.end()); reverse(p.begin(), p.end());
  double res = 0;
  for (int i = 1; i <= n; i++) {
    vector<double> prob(i + 1);
    prob[0] = 1;
    for (int j = 0; j < i; j++) {
      for (int k = i - 1; k >= 0; k--) {
        prob[k + 1] += prob[k] * p[j];
        prob[k] = prob[k] * (1 - p[j]);
      }
    }
    double curRes = 0;
    for (int j = 1; j <= i; j++) {
      curRes += exp(log(j) * j / i) * prob[j];
    }
    chmax(res, curRes);
  }
  cout << res << endl;
}
